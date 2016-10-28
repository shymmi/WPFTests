using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace DAOMock.BO
{
    public class Question : IQuestion
    {
        public IEnumerable<IAnswer> Answers
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int MaxPoints
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public Question()
        {
            Answers = new List<IAnswer>();
        }

        public Question(int id, int maxPoints, string text, IEnumerable<IAnswer> answers)
        {
            ID = id;
            MaxPoints = maxPoints;
            Text = text;
            Answers = answers;
        }
    }
}
