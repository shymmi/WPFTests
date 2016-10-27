using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAOMock.BO;

namespace TestsApplication
{
    public static class UserContext
    {
        public static User user;
        public static IDAO dao = new DAOMock.DAO();
        public static Test test;
    }
}
