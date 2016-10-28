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
        private RelayCommand _endTestCommand;
        private int _minutes;
        private int _seconds;
        private bool _isTimeLeft;
        private double _points;
        private int _maxPoints;

        public SolveTestViewModel()
        {
            _test = UserContext.test;
            _questions = new ObservableCollection<QuestionViewModel>();
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _endTestCommand = new RelayCommand(param => EndTest());
            SetUpQuestions();
            _minutes = _test.Minutes;
            _seconds = 5;
            _isTimeLeft = true;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_minutes > 0 || _seconds > 0)
            {
                _seconds -= 1;

                if (_seconds == -1)
                {
                    _minutes -= 1;
                    _seconds = 59;
                    RaisePropertyChanged("Minutes");
                }
                RaisePropertyChanged("Seconds");
            }  
            else
            {
                _isTimeLeft = false;
                RaisePropertyChanged("IsTimeLeft");
                CalculatePoints();
            } 

        }

        private void CalculatePoints()
        {
            _maxPoints = _questions.Sum(x => x.MaxPoints);
            _points = _test.CalculatePoints();
            RaisePropertyChanged("Points");
            RaisePropertyChanged("MaxPoints");
        }

        private void SetUpQuestions()
        {
            foreach (var q in _test.Questions)
            {
                _questions.Add(new QuestionViewModel((Question)q));
                _questions.Last().ClearAnswers();
            }
        }

        private void SubmitTest()
        {
            IsTimeLeft = false;
            RaisePropertyChanged("IsTimeLeft");
            CalculatePoints();
        }

        private void EndTest()
        {
            Switcher.Switch(new TestsList());
        }

        public RelayCommand EndTestCommand
        {
            get { return _endTestCommand; }
        }

        public bool IsTimeLeft
        {
            get { return _isTimeLeft; }
            set
            {
                _isTimeLeft = value;
                RaisePropertyChanged("IsTimeLeft");
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

        public double Points
        {
            get { return _points; }
            set
            {
                _points = value;
                RaisePropertyChanged("Points");
            }
        }

        public int MaxPoints
        {
            get { return _maxPoints; }
            set
            {
                _maxPoints = value;
                RaisePropertyChanged("MaxPoints");
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
