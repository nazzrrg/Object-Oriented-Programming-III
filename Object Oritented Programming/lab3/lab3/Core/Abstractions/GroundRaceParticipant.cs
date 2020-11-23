namespace lab3.Core.Abstractions
{
    public abstract class GroundRaceParticipant : IRaceParticipant
    {
        protected int RestInterval;
        protected double RestDuration;
        public int Speed { get; set; }
        public string Type { get; set; }
        public abstract double CalcTotalTime(double distance);
        
        public override string ToString()
        {
            return Type;
        }
    }
}