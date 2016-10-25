using System.Collections.Generic;

namespace Interfaces
{
    public interface IQuestion
    {
        int ID { get; set; }
        int MaxPoints { get; set; }
        string Text { get; set; }
        List<IAnswer> Answers { get; set; }

    }
}