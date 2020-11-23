using System.Collections.Generic;

namespace lab4.Core.Abstractions.Algorithms
{
    public interface IHybridLimiterLimitsSelector
    {
        public List<IBackupLimiter> SelectLimits(List<IBackupLimiter> allLimiters, List<IBackupLimiter> firedLimiters);
    }
}