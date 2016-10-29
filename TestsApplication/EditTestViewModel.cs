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
        private List<string> _ratingTypes;
        private ObservableCollection<string> _validationErrors;
        private RelayCommand _submitTestCommand;
        private RelayCommand _addQuestionCommand;
        private RelayCommand _deleteQuestionCommand;
        private RelayCommand _addAnswerCommand;
        private RelayCommand _closePopupCommand;

        public EditTestViewModel()
        {
            _test = UserContext.test;
            _ratingTypes = UserContext.dao.GetAllRatingTypes();
            _questions = new ObservableCollection<QuestionViewModel>();
            _submitTestCommand = new RelayCommand(param => SubmitTest());
            _addQuestionCommand = new RelayCommand(param => AddQuestion());
            _deleteQuestionCommand = new RelayCommand(param => DeleteQuestion());
            _addAnswerCommand = new RelayCommand(param => AddAnswer());
            _closePopupCommand = new RelayCommand(param => ClosePopup());
            _validationErrors = new ObservableCollection<string>();
            FillQuestions();

        }

        private void ClosePopup()
        {
            _validationErrors = new ObservableCollection<string>();
            RaisePropertyChanged("HasErrors");
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
            if (_selectedQuestion == null) return;
            _questions.Remove(_selectedQuestion);
            _selectedQuestion = null;
        }

        private void AddAnswer()
        {
            if (_selectedQuestion == null) return;
            _selectedQuestion.Answers.Add(new Answer());
            _selectedQuestion.Answers.Last().ID = _selectedQuestion.Answers.Max(x => x.ID) + 1;
        }

        private void SubmitTest()
        {
            Validate();         
            if (HasErrors) return;
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

        private void Validate()
        {
            var errors = new ObservableCollection<string>();

            if (_test.Title == "")
                errors.Add("Title cannot be empty.");
            else if (UserContext.dao.GetAllTests().Any(x => x.Title == _test.Title && x.ID != _test.ID))
                errors.Add("Title must be unique.");
            if (_test.Minutes < 0)
                errors.Add("Minutes must be positive.");
            if (_questions.Any(x => !x.Answers.Any(a => a.IsCorrect == true)))
                errors.Add("At least one answer must be correct");
            if (!_questions.Any(x => x.Answers.Any(a => a.Text != "")) || !_questions.Any(x => x.Text != ""))
                errors.Add("Test must have question with answer.");
            else
            {
                if (_questions.Any(x => x.Text == ""))
                    errors.Add("Questions can not be empty.");
                if (_questions.Any(x => x.Answers.Count == 0 || !x.Answers.Any(a => a.Text != "")))
                    errors.Add("Each question must have one not empty answer.");
            }

            _validationErrors = errors;
            RaisePropertyChanged("ValidationErrors");
            RaisePropertyChanged("HasErrors");
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

        public bool HasErrors
        {
            get
            {
                return _validationErrors.Any();
            }
        }

        public List<string> RatingTypes
        {
            get { return _ratingTypes; }
        }

        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged("SelectedQuestion");
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

        public RelayCommand ClosePopupCommand
        {
            get { return _closePopupCommand; }
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
