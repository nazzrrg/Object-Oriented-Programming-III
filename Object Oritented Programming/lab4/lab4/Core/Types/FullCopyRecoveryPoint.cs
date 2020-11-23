using System;
using System.Collections.Generic;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Types
{
    public class FullCopyRecoveryPoint : IRecoveryPoint
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long Size { get; set; }
        public List<string> RecoveryObjects { get; set; }
        
        public FullCopyRecoveryPoint(long id, long size, IEnumerable<string> paths)
        {
            Id = id;
            RecoveryObjects = new List<string>(paths);
            Size = size;
            CreationTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Full recovery point(id: {Id}) created on {CreationTime} of size {Size}";
        }
    }
}