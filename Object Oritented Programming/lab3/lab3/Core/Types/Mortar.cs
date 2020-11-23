using System;
using lab3.Core.Abstractions;

namespace lab3.Core.Types
{
    public class Mortar : AerialRaceParticipant
    {
        public Mortar()
        {
            Type = "Mortar";
            Speed = 20;
            DistanceReduction = 0.99;
        }

        public override double CalcTotalTime(double distance)
        {
            if (distance <= 0)
            {
                throw new Exception("Error: distance cant be negative!");
            }
            
            distance *= Math.Pow(DistanceReduction, (int)Math.Floor(distance / 1000));

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