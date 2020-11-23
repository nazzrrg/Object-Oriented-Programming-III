namespace lab3.Core.Abstractions
{
    public abstract class AerialRaceParticipant : IRaceParticipant
    {
        protected double DistanceReduction;
        public int Speed { get; set; }
        public string Type { get; set; }
        public abstract double CalcTotalTime(double distance);

        public override string ToString()
        {
            return Type;
        }
    }
}