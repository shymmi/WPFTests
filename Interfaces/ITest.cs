using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITest
    {
        bool IsMultiAnswer { get; set; }
        int ID { get; set; }
        int Minutes { get; set; }
        string Title { get; set; }
        IRating RatingType { get; set; }
        IEnumerable<IQuestion> Questions { get; set; }
    }
}
