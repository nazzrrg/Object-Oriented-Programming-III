using System;
using lab4.Core;
using lab4.Core.Algorithms;
using lab4.Core.Algorithms.Limiters;
using lab4.Core.Algorithms.Limiters.HybridLimiterSelectors;
using lab4.Core.Algorithms.PointCreators;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var backup = new BackupManager("/Users/nazzrrg/Git/Object-Oriented-Programming-III/Object Oritented Programming/lab4/lab4//Backup/backup", new SeparateStorageAlgorithm()); 
            backup.AddFiles("/Users/nazzrrg/Git/Object-Oriented-Programming-III/Object Oritented Programming/lab4/lab4/Backup/files for backup/file 1.txt",
                            "/Users/nazzrrg/Git/Object-Oriented-Programming-III/Object Oritented Programming/lab4/lab4/Backup/files for backup/file 2.txt");
            backup.SetLimits(new AnyHybridLimiterLimitsSelector(), new BackupCountLimiter(2), new BackupSizeLimiter(32));
            backup.CreatePoint(new FullCopyRecoveryPointCreator());
            Console.WriteLine(backup.GetBackupSize());
            backup.CreatePoint(new FullCopyRecoveryPointCreator());
            Console.WriteLine(backup.GetBackupSize());
            backup.CreatePoint(new FullCopyRecoveryPointCreator());
            Console.WriteLine(backup.GetBackupSize());
            backup.CreatePoint(new FullCopyRecoveryPointCreator());
            Console.WriteLine(backup.GetBackupSize());
            backup.CreatePoint(new FullCopyRecoveryPointCreator());
            Console.WriteLine(backup.GetBackupSize());
            backup.SetLimits(null, new BackupCountLimiter(1));
            backup.CleanUp();
            Console.WriteLine(backup.GetBackupSize());
        }
    }
}