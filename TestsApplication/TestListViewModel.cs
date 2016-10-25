using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Data;

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

        public TestListViewModel()
        {
            _tests = new ObservableCollection<TestViewModel>();
            _dao = new DAOMock.DAO();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_tests);
            GetAllTests();
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
    }
}
