using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Data;
using System.Windows.Input;

namespace TestsApplication
{
    class TestListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<TestViewModel> _tests;
        private IDAO _dao;
        private ListCollectionView _view;
        private IUser _user;
        private RelayCommand _loginCommand;

        public TestListViewModel()
        {
            _user = new DAOMock.BO.User();
            _tests = new ObservableCollection<TestViewModel>();
            _dao = new DAOMock.DAO();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_tests);
            _loginCommand = new RelayCommand(param => Login());
            GetAllTests();
        }

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

        public ObservableCollection<TestViewModel> Tests
        {
            get
            {
                return _tests;
            }
            set
            {
                _tests = value;
                RaisePropertyChanged("Tests");
            }
        }

        private void GetAllTests()
        {
            foreach (var t in _dao.GetAllTests())
            {
                _tests.Add(new TestViewModel(t));
            }
        }

        public RelayCommand LoginCommand
        {
            get { return _loginCommand; }
        }

        private void Login()
        {   
            if (_dao.GetAllUsers().Any(x => x.NickName == _user.NickName && x.Password == _user.Password))
            {
                User = _dao.GetAllUsers().First(x => x.NickName == _user.NickName && x.Password == _user.Password);
                User.IsNotLoggedIn = false;
                RaisePropertyChanged("User");
            }
            else
            {
                Console.WriteLine("wrong");
            }
        }
    }
}
