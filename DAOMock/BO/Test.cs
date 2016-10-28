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

        public string RatingType
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

        public Test()
        {
            IsMultiAnswer = false;
            RatingType = "No minus points";
            Questions = new ObservableCollection<IQuestion>();
        }

        public double CalculatePoints()
        {
            var points = 0.0;
            foreach(var q in Questions)
            {
                if (q.Answers.Any(x => x.IsCorrect == false && x.IsSelected == true))
                {
                    if (RatingType == "Minus points")//jezeli punkt ujemne, to za zla odpowiedz traci polowe max punktow z pytania
                    {
                        points -= (double) q.MaxPoints / 2;
                    }
                }
                else if (q.Answers.Any(x => x.IsCorrect == true && x.IsSelected == true))//jezeli nie zaznaczyl zadnej zlej to dostaje pkt za kazda dobra odpowiedz (az do max)
                {
                    points += (double) q.Answers.Count(x => x.IsCorrect == true && x.IsSelected == true) / q.Answers.Count(x => x.IsCorrect == true) * q.MaxPoints;
                }
            }

            return points;
        }

    }
}
