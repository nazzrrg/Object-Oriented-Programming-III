using lab4.Core.Abstractions.Types;

namespace lab4.Core.Abstractions.Algorithms
{
    public interface IStorageAlgorithm
    {
        public void WriteBackup(string storagePath, IRecoveryPoint recoveryPoint);
        public void DeleteBackup(string storagePath, IRecoveryPoint recoveryPoint);
    }
}