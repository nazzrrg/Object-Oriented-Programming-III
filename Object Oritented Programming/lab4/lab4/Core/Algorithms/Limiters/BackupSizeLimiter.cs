using System.Collections.Generic;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms.Limiters
{
    public class BackupSizeLimiter : IBackupLimiter
    {
        private readonly long _maxSize;

        public BackupSizeLimiter(long maxSize)
        {
            _maxSize = maxSize;
        }
        
        public List<IRecoveryPoint> Limit(List<IRecoveryPoint> recoveryPoints)
        {
            var result = new List<IRecoveryPoint>();

            foreach (var point in recoveryPoints)
            {
                if (recoveryPoints.Sum(p => p.Size) - result.Sum(p => p.Size) > _maxSize)
                    result.Add(point);
                else
                    break;
            }

            return result;
        }
    }
}