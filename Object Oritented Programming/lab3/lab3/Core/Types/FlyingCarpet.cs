using System;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class FlyingCarpet : AerialRaceParticipant
    {
        public FlyingCarpet()
        {
            Type = "Flying Carpet";
            Speed = 10;
            DistanceReduction = 0.0;
        }
        
        public override double CalcTotalTime(double distance)
        {
            if (distance <= 0)
            {
                throw new Exception("Error: distance cant be negative!");
            }
            if (1000 <= distance && distance < 5000)
            {
                DistanceReduction = 0.97;
            } else if (5000 <= distance && distance < 10000)
            {
                DistanceReduction = 0.90;
            } else if (distance > 10000)
            {
                DistanceReduction = 0.95;
            }

            distance *= DistanceReduction;
            
            var totalRaceTime = 0;

            while (distance > 0)
            {
                distance -= Speed;
                totalRaceTime += 1;
            }

            return totalRaceTime;
        }
    }
}