using System.Collections.Generic;

namespace Interfaces
{
    public interface IQuestion
    {
        int ID { get; set; }
        int MaxPoints { get; set; }
        string Text { get; set; }
        IEnumerable<IAnswer> Answers { get; set; }

    }
}