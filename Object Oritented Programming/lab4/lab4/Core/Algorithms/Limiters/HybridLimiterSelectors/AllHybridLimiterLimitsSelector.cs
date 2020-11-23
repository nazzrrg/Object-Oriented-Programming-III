using System.Collections.Generic;
using lab4.Core.Abstractions.Algorithms;

namespace lab4.Core.Algorithms.Limiters.HybridLimiterSelectors
{
    public class AllHybridLimiterLimitsSelector : IHybridLimiterLimitsSelector
    {
        public List<IBackupLimiter> SelectLimits(List<IBackupLimiter> allLimiters, List<IBackupLimiter> firedLimiters)
        {
            return allLimiters.Count == firedLimiters.Count ? allLimiters : new List<IBackupLimiter>();
        }
    }
}