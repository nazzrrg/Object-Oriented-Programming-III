using System;
using System.Collections.Generic;
using System.Linq;
using lab3.Core.Abstractions;

namespace lab3.Core
{
    public class Race<T> where T : IRaceParticipant
    {
        private readonly double _racingDistance;
        private readonly List<T> _participants = new List<T>();

        public Race(double racingDistance)
        {
            if (_racingDistance <= 0)
            {
                _racingDistance = racingDistance;
            }
            else
            {
                throw new Exception("Error: Distance can not be zero or negative");
            }
        }

        public void RegisterParticipant(params T[] participants)
        {
            foreach (var participant in participants)
            {
                _participants.Add(participant);
            }
        }

        public T GetWinner()
        {
            var winner = _participants.First();
            var winningTime = double.MaxValue;
            foreach (var participant in _participants)
            {
                var participantTime = participant.CalcTotalTime(_racingDistance);
                if (participantTime < winningTime)
                {
                    winningTime = participantTime;
                    winner = participant;
                }
            }

            return winner;
        }
        
    }
}