﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAOMock.BO
{
    public class User : IUser
    {
        public bool CanEdit
        {
            get;
            set;
        }

        public bool IsNotLoggedIn
        {
            get;
            set;
        }

        public string NickName
        {
            get;
            set;
        }

        public ITest OngoingTest
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public List<ITest> SolvedTests
        {
            get;
            set;
        }

        public User()
        {
            Password = "";
            NickName = "";
            IsNotLoggedIn = true;
        }
    }
}
