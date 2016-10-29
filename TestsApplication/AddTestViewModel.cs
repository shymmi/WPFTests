using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;
using TestsApplication.Menu;
using System.Collections.ObjectModel;
using DAOMock.BO;

namespace TestsApplication
{
    class AddTestViewModel : INotifyPropertyChanged
    {
        private ITest _test;
        private ObservableCollection<IQuestion> _questions;
        private RelayCommand _submitTestCommand;
        private RelayCommand _backCommand;
        private ObservableCollection<string> _validationErrors;

        public AddTestViewModel()
        {
            _test = UserContext.dao.CreateNewTest();
            _questions = new ObservableCollection<IQuestion>(_test.Questions);
            _test.ID = UserContext.dao.GetAllTests().Max(x => x.ID) + 1;
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _backCommand = new RelayCommand(param => GoBack());
            _validationErrors = new ObservableCollection<string>();
        }

        private void GoBack()
        {
            Switcher.Switch(new TestsList());
        }

        private void SubmitTest()
        {
            Validate();
            if (HasErrors) return;
            UserContext.dao.AddTest(_test);
            Switcher.Switch(new TestsList());
        }

        public ITest Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                RaisePropertyChanged("Test");
            }
        }

        public RelayCommand SubmitTestCommand
        {
            get
            {
                return _submitTestCommand;
            }
        }

        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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

            if (_test.Title == "")
                errors.Add("Title cannot be empty.");
            else
            {
                if (UserContext.dao.GetAllTests().Any(x => x.Title == _test.Title))
                {
                    errors.Add("Test title must be unique.");
                }
            }
            if (_test.Minutes < 0)
                errors.Add("Minutes must be positive.");

            _validationErrors = errors;
            RaisePropertyChanged("ValidationErrors");
            RaisePropertyChanged("HasErrors");
        }
    }
}
