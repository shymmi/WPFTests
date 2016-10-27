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
using TestsApplication.Menu;
using DAOMock.BO;

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

        
        private ObservableCollection<Test> _tests;
        private Test _selectedTest;
        private IDAO _dao;
        private IUser _user;
        private RelayCommand _logoutCommand;
        private RelayCommand _addTestCommand;
        private RelayCommand _solveTestCommand;
        private RelayCommand _editTestCommand;

        public TestListViewModel()
        {
            UserContext.test = null;

            _user = UserContext.user;
            _tests = new ObservableCollection<Test>();
            _dao = UserContext.dao;

            _logoutCommand = new RelayCommand(param => Logout());
            _addTestCommand = new RelayCommand(param => AddTest());
            _solveTestCommand = new RelayCommand(param => SolveTest());
            _editTestCommand = new RelayCommand(param => EditTest());

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

        public RelayCommand LogoutCommand
        {
            get { return _logoutCommand; }
        }

        public RelayCommand AddTestCommand
        {
            get { return _addTestCommand; }
        }

        public RelayCommand SolveTestCommand
        {
            get { return _solveTestCommand; }
        }

        public RelayCommand EditTestCommand
        {
            get { return _editTestCommand; }
        }

        public Test SelectedTest
        {
            get
            {
                return _selectedTest;
            }
            set
            {
                _selectedTest = value;
                RaisePropertyChanged("SelectedTest");
            }
        }

        public ObservableCollection<Test> Tests
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
                _tests.Add((Test)t);
            }
        }

        private void AddTest()
        {
            Switcher.Switch(new TestAdd());
        }

        private void SolveTest()
        {
            if (SelectedTest == null) return;
            UserContext.test = SelectedTest;
            Switcher.Switch(new TestSolve());
        }

        private void EditTest()
        {
            if (SelectedTest == null) return;
            UserContext.test = SelectedTest;
            Switcher.Switch(new TestEdit());
        }

        private void Logout()
        {
            Switcher.Switch(new Login());
        }
    }
}
