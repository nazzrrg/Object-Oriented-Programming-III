using System;
using System.Drawing;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;

namespace lab4.Core.Algorithms
{
    public class SeparateStorageAlgorithm : IStorageAlgorithm
    {
        public void WriteBackup(string storagePath, IRecoveryPoint recoveryPoint)
        {
            Console.WriteLine("----- SEPARATE STORAGE ALGORITHM -----");
            Console.WriteLine($"Written {recoveryPoint}");
            Console.WriteLine($"to {storagePath}\n Backed up files:");
            
            foreach (var fileName in recoveryPoint.RecoveryObjects)
            {
                Console.WriteLine(fileName);
            }
            
            Console.WriteLine("--------------------------------------");
        }

        public void DeleteBackup(string storagePath, IRecoveryPoint recoveryPoint)
        {
            Console.WriteLine("----- SEPARATE STORAGE ALGORITHM -----");
            Console.WriteLine($"Removed {recoveryPoint}");
            Console.WriteLine($"from {storagePath}\n With backed up files:");
            
            foreach (var fileName in recoveryPoint.RecoveryObjects)
            {
                Console.WriteLine(fileName);
            }
            
            Console.WriteLine("--------------------------------------");
        }
    }
}