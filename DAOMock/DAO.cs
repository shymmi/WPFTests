using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock
{
    public class DAO : IDAO
    {   //TODO
        public void AddTest(ITest test)
        {
            throw new NotImplementedException();
        }

        public ITest CreateNewTest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IQuestion> GetAllQuestions(ITest test)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITest> GetAllTests()
        {
            throw new NotImplementedException();
        }
    }
}
