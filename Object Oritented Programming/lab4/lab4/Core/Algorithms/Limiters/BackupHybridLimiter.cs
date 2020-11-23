using System.Collections.Generic;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms.Limiters
{
    public class BackupHybridLimiter : IBackupLimiter
    {
        private readonly List<IBackupLimiter> _limiters;
        private readonly IHybridLimiterLimitsSelector _limitsSelector;

        public BackupHybridLimiter(IBackupLimiter[] limiters, IHybridLimiterLimitsSelector limitsSelector)
        {
            _limiters = limiters.ToList();
            _limitsSelector = limitsSelector;
        }
        
        public List<IRecoveryPoint> Limit(List<IRecoveryPoint> recoveryPoints)
        {
            var selectedLimits = _limitsSelector.SelectLimits(_limiters,
                _limiters.FindAll(limiter => limiter.Limit(recoveryPoints).Count > 0));
            
            var result = new HashSet<IRecoveryPoint>();
            foreach (var point in selectedLimits.SelectMany(limit => limit.Limit(recoveryPoints)))
            {
                result.Add(point);
            }
            
            return result.ToList();
        }
        
    }
}