using System.IO;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;
using lab4.Core.Types;

namespace lab4.Core.Algorithms.PointCreators
{
    public class FullCopyRecoveryPointCreator : IRecoveryPointCreator
    {
        public IRecoveryPoint CreatePoint(long id, string[] filePaths, IRecoveryPoint[] previousPoints)
        {
            return new FullCopyRecoveryPoint(id, filePaths.Select(p => new FileInfo(p).Length).Sum(), filePaths);
        }
    }
}