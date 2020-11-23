using System;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class TwoHumpedCamel : GroundRaceParticipant
    {
        public TwoHumpedCamel()
        {
            Speed = 10;
            RestInterval = 30;
            RestDuration = 5;
            Type = "Two-Humped Camel";
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
                    RestDuration = 8;
                }
            }

            return totalRaceTime + totalRestDuration;
        }
    }
}