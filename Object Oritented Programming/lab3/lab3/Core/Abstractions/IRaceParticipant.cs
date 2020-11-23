namespace lab3.Core.Abstractions
{
    public interface IRaceParticipant
    {
        double CalcTotalTime(double distance);
        int Speed { get; set; }
        string Type { get; set; }
    }
}