using System;
using System.Runtime.CompilerServices;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class Broom : AerialRaceParticipant
    {
        public Broom()
        {
            Type = "Broom";
            Speed = 8;
            DistanceReduction = 0.94;
        }

        public override double CalcTotalTime(double distance)
        {
            if (distance <= 0)
            {
                throw new Exception("Error: distance cant be negative!");
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