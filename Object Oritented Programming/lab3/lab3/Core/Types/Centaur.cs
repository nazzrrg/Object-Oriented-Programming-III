using System;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class Centaur : GroundRaceParticipant
    {
        public Centaur()
        {
            Type = "Centaur";
            Speed = 15;
            RestDuration = 2;
            RestInterval = 8;
        }
        
        public override double CalcTotalTime(double distance)
        {
            if (distance <= 0)
            {
                throw new Exception("Error: distance cant be negative!");
            }
            
            var totalRaceTime = 0;
            var totalRestDuration = 0.0;

            while (distance > 0)
            {
                distance -= Speed;
                totalRaceTime += 1;

                if (totalRaceTime % RestInterval == 0)
                {
                    totalRestDuration += RestDuration;
                }
            }

            return totalRaceTime + totalRestDuration;
        }
    }
}