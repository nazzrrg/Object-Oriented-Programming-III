using System;
using lab3.Core;
using lab3.Core.Types;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var race1 = new Race<Core.Abstractions.IRaceParticipant>(12345);
            race1.RegisterParticipant(new Broom(), new Centaur(), new SpeedyBoots());
            Console.WriteLine(race1.GetWinner());
            
            var race2 = new Race<Core.Abstractions.AerialRaceParticipant>(12345);
            race2.RegisterParticipant(new Broom(), new FlyingCarpet());
            Console.WriteLine(race2.GetWinner());
            
            var race3 = new Race<Core.Abstractions.GroundRaceParticipant>(123654);
            race3.RegisterParticipant(new Centaur(), new FastBoyCamel(), new TwoHumpedCamel());
            Console.WriteLine(race3.GetWinner());
            
            // var race4 = new Race<Core.Abstractions.AerialRaceParticipant>(123654);
            // race4.RegisterParticipant(new );
            
        }
    }
}