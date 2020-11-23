using System;
using System.Collections.Generic;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms.Limiters
{
    public class BackupDateLimiter : IBackupLimiter
    {
        private readonly DateTime _minDate;

        public BackupDateLimiter(DateTime minDate)
        {
            _minDate = minDate;
        }
        
        public List<IRecoveryPoint> Limit(List<IRecoveryPoint> recoveryPoints)
        {
            return recoveryPoints.FindAll(p => p.CreationTime < _minDate);
        }
    }
}