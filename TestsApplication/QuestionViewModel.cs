using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel;
using DAOMock.BO;

namespace TestsApplication
{
    public class QuestionViewModel : INotifyPropertyChanged
    {

        private Question _question;

        public QuestionViewModel(Question q)
        {
            _question = q;
            
            FillAnswers(q);
        }

        private void FillAnswers(Question question)
        {   
            var t = new ObservableCollection<Answer>();

            foreach (var a in question.Answers)
            {
                t.Add((Answer)a);
            }
            _question.Answers = t;
        }

        public ObservableCollection<Answer> Answers
        {
            get { return (ObservableCollection<Answer>)(_question.Answers); }
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
        
        public void ClearAnswers()
        {
            foreach (var a in _question.Answers)
            {
                a.IsSelected = false;
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
