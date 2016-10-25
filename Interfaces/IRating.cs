using System.Collections.Generic;

namespace Interfaces
{
    public interface IRating
    {
        string Name { get; set; }

        double CalculatePoints(ITest Test);
    }
}