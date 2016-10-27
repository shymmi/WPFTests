using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Collections.ObjectModel;

namespace DAOMock.BO
{
    public class Test : ITest
    {
        public int ID
        {
            get;
            set;
        }

        public bool IsMultiAnswer
        {
            get;
            set;
        }

        public IEnumerable<IQuestion> Questions
        {
            get;
            set;
        }

        public IRating RatingType
        {
            get;
            set;
        }

        public int Minutes
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
        
        public void AddQuestions(IEnumerable<IQuestion> questions)
        {
            Questions = questions;
        }

        public Test()
        {
            IsMultiAnswer = false;
            Title = "";
            Questions = new List<IQuestion>();
        }
    }
}
