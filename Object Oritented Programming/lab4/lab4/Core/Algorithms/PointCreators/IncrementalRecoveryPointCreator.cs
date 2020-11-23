using System;
using System.IO;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;
using lab4.Core.Types;

namespace lab4.Core.Algorithms.PointCreators
{
    public class IncrementalRecoveryPointCreator : IRecoveryPointCreator
    {
        public IRecoveryPoint CreatePoint(long id, string[] filePaths, IRecoveryPoint[] previousPoints)
        {
            var size = Convert.ToInt64(
                           filePaths.Select(s1 => previousPoints.Last().RecoveryObjects.Find(s1.Equals))
                               .Where(s => !string.IsNullOrEmpty(s)).Select(s => new FileInfo(s).Length).Sum() * new Random().NextDouble()/4)
                       + 
                       filePaths.Select(s1 => previousPoints.Last().RecoveryObjects.Find(s1.Equals))
                           .Where(s => !string.IsNullOrEmpty(s)).Select(s => new FileInfo(s).Length).Sum();
            
            return new IncrementalRecoveryPoint(id, size, filePaths);
        }
    }
}