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
    class EditTestViewModel : INotifyPropertyChanged
    {
        private Test _test;
        private ObservableCollection<IQuestion> _questions;
        private IQuestion _selectedQuestion;
        private IAnswer _selectedAnswer;
        private RelayCommand _submitTestCommand;
        private RelayCommand _backCommand;
        private RelayCommand _addQuestionCommand;
        private RelayCommand _deleteQuestionCommand;
        private RelayCommand _addAnswerCommand;
        private RelayCommand _deleteAnswerCommand;

        public EditTestViewModel()
        {
            _test = UserContext.test;
            _questions = new ObservableCollection<IQuestion>(_test.Questions);
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _backCommand = new RelayCommand(param => GoBack());
            _addQuestionCommand = new RelayCommand(param => AddQuestion());
            _deleteQuestionCommand = new RelayCommand(param => DeleteQuestion());
            _addAnswerCommand = new RelayCommand(param => AddAnswer());
            _deleteAnswerCommand = new RelayCommand(param => DeleteAnswer());
        }

        private void AddQuestion()
        {
            _questions.Add(new Question());
            _questions.Last().ID = _questions.Count > 0 ? _questions.Max(x => x.ID) + 1 : 1;
        }

        private void DeleteQuestion()
        {
            _questions.Remove(SelectedQuestion);
            SelectedQuestion = null;
        }

        private void AddAnswer()
        {
            //_selectedQuestion.Answers.Add(new Answer());
        }

        private void DeleteAnswer()
        {
            //add one answer
        }

        private void GoBack()
        {
            Switcher.Switch(new TestsList());
        }

        private void SubmitTest()
        {
            if (_test.Title == "") return;
            _test.Questions = _questions;
            UserContext.dao.EditTest(_test);
            Switcher.Switch(new TestsList());
        }

        public IAnswer SelectedAnswer
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                RaisePropertyChanged("SelectedAnswer");
            }
        }

        public IQuestion SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged("SelectedQuestion");
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

        public ObservableCollection<IQuestion> Questions
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

        public RelayCommand AddQuestionCommand
        {
            get
            {
                return _addQuestionCommand;
            }
        }

        public RelayCommand AddAnswerCommand
        {
            get
            {
                return _addAnswerCommand;
            }
        }

        public RelayCommand DeleteQuestionCommand
        {
            get
            {
                return _deleteQuestionCommand;
            }
        }

        public RelayCommand DeleteAnswerCommand
        {
            get
            {
                return _deleteAnswerCommand;
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
