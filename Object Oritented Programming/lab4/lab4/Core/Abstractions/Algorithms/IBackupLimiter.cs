using System.Collections.Generic;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Abstractions.Algorithms
{
    public interface IBackupLimiter
    {
        public List<IRecoveryPoint> Limit(List<IRecoveryPoint> recoveryPoints);
    }
}