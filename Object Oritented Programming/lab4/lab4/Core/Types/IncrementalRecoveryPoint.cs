using System;
using System.Collections.Generic;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Types
{
    public class IncrementalRecoveryPoint : IRecoveryPoint
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long Size { get; set; }
        public List<string> RecoveryObjects { get; set; }

        public IncrementalRecoveryPoint(long id, long size, IEnumerable<string> paths)
        {
            Id = id;
            CreationTime = DateTime.Now;
            RecoveryObjects = new List<string>(paths);
            Size = size;
        }
        
        public override string ToString()
        {
            return $"Incremental recovery point(id: {Id}) created on {CreationTime} of size {Size}";
        }
    }
}