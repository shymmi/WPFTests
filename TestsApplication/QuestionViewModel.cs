using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;

namespace TestsApplication
{
    public class QuestionViewModel : INotifyPropertyChanged
    {

        private IQuestion _question;

        public QuestionViewModel(IQuestion q)
        {
            _question = q;
        }

        public ObservableCollection<IAnswer> Answers
        {
            get { return (ObservableCollection<IAnswer>)(_question.Answers); }
            set
            {
                _question.Answers = value;
                RaisePropertyChanged("Answers");
            }
        }

        public int ID
        {
            get { return _question.ID; }
            set
            {
                _question.ID = value;
                RaisePropertyChanged("ID");
            }
        }

        public int MaxPoints
        {
            get { return _question.MaxPoints; }
            set
            {
                _question.MaxPoints = value;
                RaisePropertyChanged("MaxPoints");
            }
        }

        public string Text
        {
            get { return _question.Text; }
            set
            {
                _question.Text = value;
                RaisePropertyChanged("Text");
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
