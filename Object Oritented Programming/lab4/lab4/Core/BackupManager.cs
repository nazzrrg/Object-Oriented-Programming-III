using System;
using System.Collections.Generic;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Algorithms;
using lab4.Core.Algorithms.Limiters;
using lab4.Core.Algorithms.PointCreators;
using lab4.Core.Types;

namespace lab4.Core
{
    public class BackupManager
    {
        private readonly Backup _backup;
        private IBackupLimiter _limiter;

        public BackupManager(string backupPath, IStorageAlgorithm algorithm)
        {
            _backup = new Backup(backupPath, algorithm);
        }

        public void AddFiles(params string[] filePaths)
        {
            _backup.FilePaths = new List<string>(filePaths);
        }

        public void SetLimits(IHybridLimiterLimitsSelector hybridLimiterLimitsSelector = null, params IBackupLimiter[] limiters)
        {
            if (limiters.Length == 1)
            {
                _limiter = limiters[0];
            }
            else
            {
                if (hybridLimiterLimitsSelector is null)
                {
                    throw new Exception("Error: unable to use hybrid backup limit without provided selector");
                }
                _limiter = new BackupHybridLimiter(limiters, hybridLimiterLimitsSelector);
            }
        }

        public void CreatePoint(IRecoveryPointCreator creator)
        {
            _backup.CreateRecoveryPoint(_backup.IsEmpty() ? new FullCopyRecoveryPointCreator() : creator);

            if (!(_limiter is null))
                CleanUp();
        }

        public void CleanUp()
        {
            if (_limiter is null) 
                throw new Exception("Error: Can not clean up backups without limiters set"); 
            
            if (!_backup.CleanUpPoints(_limiter))
            {
                Console.WriteLine("Caution: Not all old backups could be cleaned up! Please make a full copy and try again.");
            }
        }

        public long GetBackupSize()
        {
            return _backup.GetSize();
        }
    }
}