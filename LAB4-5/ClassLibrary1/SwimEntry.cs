

namespace ClassLibrary1
{
    public class SwimEntry
    {
        public SwimEvent Event { get; set; }
        public byte HeatNumber { get; set; }
        public byte LaneNumber { get; set; }
        public TimeSpan Result { get; set; }
        public TimeSpan SeedTime { get; set; }
        public Swimmer Swimmer { get; set; }
        public SwimEntry(Swimmer swimmer, SwimEvent swimEvent, TimeSpan seedTime)
        {
            Swimmer = swimmer;
            Event = swimEvent;
            SeedTime = seedTime;
        }
        public override string ToString()
        {
            int age = DateTime.Now.Year - Swimmer.BDay.Year;
            return $"{Swimmer.Id,-4}{Swimmer.Name,-20} {Swimmer.Sex,-7} {age,-6} {Swimmer.Club,-15} {SeedTime:mm\\:ss\\.ff}";
        }
    }
}
