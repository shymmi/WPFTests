using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TestsApplication
{
    class TestViewModel : INotifyPropertyChanged
    {
        private ITest _test;

        public TestViewModel(ITest test)
        {
            _test = test;
            //Validate();
        }

        public bool IsMultiAnswer
        {
            get
            {
                return _test.IsMultiAnswer;
            }
            set
            {
                _test.IsMultiAnswer = value;
                RaisePropertyChanged("IsMultiAnswer");
            }
        }
        public int ID
        {
            get
            {
                return _test.ID;
            }
            set
            {
                _test.ID = value;
                RaisePropertyChanged("ID");
            }
        }
        public int Minutes
        {
            get
            {
                return _test.Minutes;
            }
            set
            {
                _test.Minutes = value;
                RaisePropertyChanged("Minutes");
            }
        }
        public string Title
        {
            get
            {
                return _test.Title;
            }
            set
            {
                _test.Title = value;
                RaisePropertyChanged("Title");
            }

        }
        public IRating RatingType
        {
            get
            {
                return _test.RatingType;
            }
            set
            {
                _test.RatingType = value;
                RaisePropertyChanged("RatingType");
            }
        }
        public ObservableCollection<IQuestion> Questions
        {
            get
            {
                return new ObservableCollection<IQuestion>(_test.Questions);
            }
            set
            {
                _test.Questions = value;
                RaisePropertyChanged("Questions");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                //Validate();
            }
        }
    }
}
