using lab4.Core.Abstractions.Types;

namespace lab4.Core.Abstractions.Algorithms
{
    public interface IRecoveryPointCreator
    {
        public IRecoveryPoint CreatePoint(long id, string[] filePaths, IRecoveryPoint[] previousPoints);
    }
}