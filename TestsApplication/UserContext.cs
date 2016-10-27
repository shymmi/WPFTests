using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace TestsApplication
{
    public static class UserContext
    {
        public static IUser user;
        public static IDAO dao = new DAOMock.DAO();
        public static ITest test;
    }
}
