
namespace ClassLibrary1
{
    public class TimeFinalSeedingService : SeedingService
    {
        public override int SeedEvent(SwimEvent swimEvent)
        {
            List<SwimEntry> swimEntries = swimEvent.SwimEntries.OrderBy(e => e.SeedTime).ToList();
            List<SwimEntry> swimEntry = swimEntries;
            int total = swimEntry.Count();
            int heatNumbers = (int)Math.Ceiling((double)total / poolLanes);

            int idx = 0;
            for (int heatNumber = 1; heatNumber <= heatNumbers; heatNumber++)
            {
                List<SwimEntry> group = new List<SwimEntry>();
                for (int i = 0; i < poolLanes && idx < total; i++, idx++)
                    group.Add(swimEntry[idx]);

                int[] laneOrder = new int[] { 4, 5, 3, 6, 2, 7, 1, 8 };
                for (int i = 0; i < group.Count; i++)
                {
                    group[i].HeatNumber = (byte)heatNumber;
                    group[i].LaneNumber = (byte)laneOrder[i];
                }
            }
            return heatNumbers;
        }
        public TimeFinalSeedingService(Meet meet) : base(meet)
        {

        }
    }
}
