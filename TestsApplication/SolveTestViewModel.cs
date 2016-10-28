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
    class SolveTestViewModel : INotifyPropertyChanged
    {
        private Test _test;
        private ObservableCollection<QuestionViewModel> _questions;
        private RelayCommand _submitTestCommand;
        private RelayCommand _backCommand;
        private int _minutes;
        private int _seconds;
        private bool _isTimeUp;

        public SolveTestViewModel()
        {
            _test = UserContext.test;
            _questions = new ObservableCollection<QuestionViewModel>();
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _backCommand = new RelayCommand(param => GoBack());
            FillQuestions();
            _minutes = _test.Minutes;
            _seconds = 5;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        { 
            _seconds -= 1;
            
            if (_seconds == -1)
            {
                _minutes -= 1;
                _seconds = 59;
                RaisePropertyChanged("Minutes");
            }
            RaisePropertyChanged("Seconds");

            if (_minutes == 0 && _seconds == 0)
            {
                IsTimeUp = true;
            }       

        }

        private void FillQuestions()
        {
            foreach (var q in _test.Questions)
            {
                _questions.Add(new QuestionViewModel((Question)q));
            }
        }

        private void GoBack()
        {
            Switcher.Switch(new TestsList());
        }

        private void SubmitTest()
        {
            if (_test.Title == "") return;

            //sum up
            Switcher.Switch(new TestsList());
        }

        public bool IsTimeUp
        {
            get { return _isTimeUp; }
            set
            {
                _isTimeUp = value;
                RaisePropertyChanged("IsTimeUp");
            }    
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                RaisePropertyChanged("Minutes");
            }
        }

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                RaisePropertyChanged("Seconds");
            }
        }

        public Test Test
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

        public ObservableCollection<QuestionViewModel> Questions
        {
            get
            {
                return _questions;
            }
            set
            {
                _questions = value;
                RaisePropertyChanged("Question");
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
    }
}
