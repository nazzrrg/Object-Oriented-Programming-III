using System;
using System.Collections.Generic;

namespace lab4.Core.Abstractions.Types
{
    public interface IRecoveryPoint
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long Size { get; set; }
        public List<string> RecoveryObjects { get; set; }
        
    }
}