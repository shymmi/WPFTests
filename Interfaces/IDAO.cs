using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<ITest> GetAllTests();
        IEnumerable<IUser> GetAllUsers();

        ITest CreateNewTest();
        void AddTest(ITest test);
        void EditTest(ITest test);
    }
}
