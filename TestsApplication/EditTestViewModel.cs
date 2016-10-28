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
        private ObservableCollection<QuestionViewModel> _questions;
        private QuestionViewModel _selectedQuestion;
        //private Answer _selectedAnswer;
        private List<string> _ratingTypes;
        private RelayCommand _submitTestCommand;
        private RelayCommand _addQuestionCommand;
        private RelayCommand _deleteQuestionCommand;
        private RelayCommand _addAnswerCommand;
        //private RelayCommand _deleteAnswerCommand;

        public EditTestViewModel()
        {
            _test = UserContext.test;
            _ratingTypes = UserContext.dao.GetAllRatingTypes();
            _questions = new ObservableCollection<QuestionViewModel>();
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _addQuestionCommand = new RelayCommand(param => AddQuestion());
            _deleteQuestionCommand = new RelayCommand(param => DeleteQuestion());
            _addAnswerCommand = new RelayCommand(param => AddAnswer());
            //_deleteAnswerCommand = new RelayCommand(param => DeleteAnswer());
            FillQuestions();
        }

        private void FillQuestions()
        {   
            foreach (var q in _test.Questions)
            {
                _questions.Add(new QuestionViewModel((Question)q));
            }          
        }

        private void AddQuestion()
        {
            _questions.Add(new QuestionViewModel(new Question()));
            _questions.Last().ID = _questions.Count > 0 ? _questions.Max(x => x.ID) + 1 : 1;
        }

        private void DeleteQuestion()
        {
            if (_selectedQuestion == null) return;//always null
            _questions.Remove(_selectedQuestion);
            _selectedQuestion = null;
        }

        private void AddAnswer()
        {
            if (_selectedQuestion == null) return;
            _selectedQuestion.Answers.Add(new Answer());
            _selectedQuestion.Answers.Last().ID = _selectedQuestion.Answers.Max(x => x.ID) + 1;
        }

        //private void DeleteAnswer()
        //{
        //    if (_selectedAnswer == null) return;
        //    Console.WriteLine("Answer: {0}", _selectedAnswer.Text);
        //    _selectedQuestion.Answers.Remove(_selectedAnswer);          
        //    _selectedAnswer = null;
        //}

        private void SubmitTest()
        {
            if (_test.Title == "") return;
            if (!_questions.Any(x => x.Answers.Any(a => a.Text != ""))) return;
            if (_questions.Any(x => x.Answers.Count == 0 || !x.Answers.Any(a => a.Text != ""))) return;
            RemoveEmptyAnswers();

            var t = new List<IQuestion>();
            foreach (var q in _questions)
            {
                t.Add(new Question(q.ID, q.MaxPoints, q.Text, q.Answers));
            }
            _test.Questions = t;
            UserContext.dao.EditTest(_test);
            Switcher.Switch(new TestsList());
        }

        private void RemoveEmptyAnswers()
        {
            foreach (var q in _questions)
            {
                foreach (var a in q.Answers.ToList())
                {
                    if (a.Text == "") q.Answers.Remove(a);
                }
            }
        }

        public List<string> RatingTypes
        {
            get { return _ratingTypes; }
        }


        //public Answer SelectedAnswer
        //{
        //    get { return _selectedAnswer; }
        //    set
        //    {
        //        _selectedAnswer = value;
        //        RaisePropertyChanged("SelectedAnswer");
        //    }
        //}

        public QuestionViewModel SelectedQuestion
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

        //public RelayCommand DeleteAnswerCommand
        //{
        //    get
        //    {
        //        return _deleteAnswerCommand;
        //    }
        //}

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
