﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace DAOMock.BO
{
    public class Question : IQuestion
    {
        public List<IAnswer> Answers
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
    }
}