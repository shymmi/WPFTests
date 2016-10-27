using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAOMock.BO
{
    public class Answer : IAnswer
    {
        public int ID
        {
            get;
            set;
        }

        public bool IsCorrect
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public Answer()
        {
            IsSelected = false;
        }
    }
}
