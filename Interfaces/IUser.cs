using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        string NickName { get; set; }
        string Password { get; set; }
        bool CanEdit { get; set; }
        List<ITest> SolvedTests { get; set; }
        ITest OngoingTest { get; set; }
    }
}
