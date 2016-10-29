using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;
using TestsApplication.Menu;
using System.Collections.ObjectModel;

namespace TestsApplication
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private IUser _user;
        private RelayCommand _loginCommand;
        private ObservableCollection<string> _validationErrors;

        public IUser User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        public RelayCommand LoginCommand
        {
            get { return _loginCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoginViewModel()
        {
            _loginCommand = new RelayCommand(param => Login());
            _user = new DAOMock.BO.User();
            _validationErrors = new ObservableCollection<string>();
        }

        private void Login()
        {
            Validate();
            if (HasErrors) return;

            User = UserContext.dao.GetAllUsers().First(x => x.NickName == _user.NickName && x.Password == _user.Password);
            UserContext.user = (DAOMock.BO.User)User;
            Switcher.Switch(new TestsList());
        }

        public bool HasErrors
        {
            get
            {
                return _validationErrors.Count > 0;
            }
        }

        public ObservableCollection<string> ValidationErrors
        {
            get { return _validationErrors; }
            set
            {
                _validationErrors = value;
                RaisePropertyChanged("ValidationErrors");
            }
        }

        public void Validate()
        {
            var errors = new ObservableCollection<string>();

            if (User.NickName == "")
                errors.Add("Username cannot be empty.");
            else
            {
                if (!UserContext.dao.GetAllUsers().Any(x => x.NickName == User.NickName))
                {
                    errors.Add("Such a username does not exist.");
                }
                else if (!UserContext.dao.GetAllUsers().Any(x => x.NickName == User.NickName && x.Password == User.Password))
                {
                    errors.Add("Provided password is incorrect.");
                }
            }

            _validationErrors = errors;
            RaisePropertyChanged("ValidationErrors");
            RaisePropertyChanged("HasErrors");
        }
    }
}
