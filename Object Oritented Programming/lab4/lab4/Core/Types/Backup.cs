using System;
using System.Collections.Generic;
using System.Linq;
using lab4.Core.Abstractions.Algorithms;
using lab4.Core.Abstractions.Types;
using lab4.Core.Algorithms;

namespace lab4.Core.Types
{
    public class Backup
    {
        private readonly List<IRecoveryPoint> _recoveryPoints;
        public List<string> FilePaths { get; set; }
        private long _lastId;
        private readonly IStorageAlgorithm _storageAlgorithm;
        private readonly string _backupPath;
        private readonly PointDeleter _pointDeleter;

        public Backup(string backupPath, IStorageAlgorithm algorithm)
        {
            _storageAlgorithm = algorithm;
            _recoveryPoints = new List<IRecoveryPoint>();
            FilePaths = new List<string>();
            _lastId = 0;
            _backupPath = backupPath;
            _pointDeleter = new PointDeleter();
        }

        public void CreateRecoveryPoint(IRecoveryPointCreator pointCreator)
        {
            _recoveryPoints.Add(pointCreator.CreatePoint(_lastId, FilePaths.ToArray(), _recoveryPoints.ToArray()));
            _lastId++;
            _storageAlgorithm.WriteBackup(_backupPath, _recoveryPoints.Last());
        }

        public bool CleanUpPoints(IBackupLimiter limiter)
        {
            var allPointsDeleted = true;

            if (limiter.Limit(_recoveryPoints) is null) return false;
            
            foreach (var recoveryPoint in limiter.Limit(_recoveryPoints))
            {
                if (_pointDeleter.CanDeletePoint(recoveryPoint, _recoveryPoints.ToArray()))
                {
                    _storageAlgorithm.DeleteBackup(_backupPath, recoveryPoint);
                    _recoveryPoints.Remove(recoveryPoint);
                }
                else
                {
                    allPointsDeleted = false;
                }
            }

            return allPointsDeleted;
        }

        public bool IsEmpty()
        {
            return _recoveryPoints.Count == 0;
        }

        public long GetSize()
        {
            return _recoveryPoints.Sum(p => p.Size);
        }
    }
}