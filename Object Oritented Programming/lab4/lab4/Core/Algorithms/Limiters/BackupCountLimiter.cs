using System.Collections.Generic;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms.Limiters
{
    public class BackupCountLimiter : IBackupLimiter
    {
        private readonly long _maxCount;

        public BackupCountLimiter(long maxCount)
        {
            _maxCount = maxCount;
        }
        
        public List<IRecoveryPoint> Limit(List<IRecoveryPoint> recoveryPoints)
        {
            var result = new List<IRecoveryPoint>();

            foreach (var point in recoveryPoints)
            {
                if (recoveryPoints.Count - result.Count > _maxCount)
                    result.Add(point);
                else
                    break;
            }

            return result;
        }
    }
}