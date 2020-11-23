using System.Linq;
using lab4.Core.Abstractions.Types;
using lab4.Core.Types;

namespace lab4.Core.Algorithms
{
    public class PointDeleter
    {
        public bool CanDeletePoint(IRecoveryPoint point, IRecoveryPoint[] points)
        {
            return points.Any(p => p.GetType() == typeof(FullCopyRecoveryPoint) && p.Id > point.Id);
        }
    }
}