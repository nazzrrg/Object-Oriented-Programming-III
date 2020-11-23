using System;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class SpeedyBoots : GroundRaceParticipant
    {
        public SpeedyBoots()
        {
            Type = "Speedy Boots";
            Speed = 6;
            RestDuration = 10;
            RestInterval = 60;
        }

        public override double CalcTotalTime(double distance)
        {
            if (distance <= 0)
            {
                throw new Exception("Error: distance cant be negative!");
            }
            
            var totalRaceTime = 0;
            var restsCount = 0;
            var totalRestDuration = 0.0;

            while (distance > 0)
            {
                distance -= Speed;
                totalRaceTime += 1;

                if (totalRaceTime % RestInterval == 0)
                {
                    totalRestDuration += RestDuration;
                    restsCount++;
                }

                if (restsCount > 0)
                {
                    RestDuration = 5;
                }
            }

            return totalRaceTime + totalRestDuration;
        }
    }
}