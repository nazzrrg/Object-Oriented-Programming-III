using System;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms
{
    public class JoinedStorageAlgorithm : IStorageAlgorithm
    {
        public void WriteBackup(string storagePath, IRecoveryPoint recoveryPoint)
        {
            Console.WriteLine("----- JOINED STORAGE ALGORITHM -----");
            Console.WriteLine($"Added {recoveryPoint}");
            Console.WriteLine($"to file {storagePath}\n Backed up files:");
            
            foreach (var fileName in recoveryPoint.RecoveryObjects)
            {
                Console.WriteLine(fileName);
            }
            
            Console.WriteLine("--------------------------------------");
        }

        public void DeleteBackup(string storagePath, IRecoveryPoint recoveryPoint)
        {
            Console.WriteLine("----- JOINED STORAGE ALGORITHM -----");
            Console.WriteLine($"Removed {recoveryPoint}");
            Console.WriteLine($"from file {storagePath}\n With backed up files:");
            
            foreach (var fileName in recoveryPoint.RecoveryObjects)
            {
                Console.WriteLine(fileName);
            }
            
            Console.WriteLine("--------------------------------------");
        }
    }
}