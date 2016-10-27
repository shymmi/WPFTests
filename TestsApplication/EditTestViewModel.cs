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
        }

        private void AddQuestion()
        {
            //add one answer
        }

        private void DeleteQuestion()
        {
            //add one answer
        }

        private void AddAnswer()
        {
            //add one answer
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

        public ObservableCollection<IQuestion> Question
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
