using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;
using TestsApplication.Menu;

namespace TestsApplication
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private IDAO _dao;
        private IUser _user;
        private RelayCommand _loginCommand;

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
            _dao = new DAOMock.DAO();
        }

        private void Login()
        {
            if (_dao.GetAllUsers().Any(x => x.NickName == _user.NickName && x.Password == _user.Password))
            {
                User = _dao.GetAllUsers().First(x => x.NickName == _user.NickName && x.Password == _user.Password);

                UserContext.user = (DAOMock.BO.User)User;
                Switcher.Switch(new TestsList());
            }
        }
    }
}
