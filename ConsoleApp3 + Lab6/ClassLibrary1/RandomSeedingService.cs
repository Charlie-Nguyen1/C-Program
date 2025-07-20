
namespace ClassLibrary1
{
    public class RandomSeedingService : SeedingService
    {
        private readonly Random random = new Random();
        public RandomSeedingService(Meet meet) : base(meet) { }

        public override int SeedEvent(SwimEvent swimEvent)
        {
            List<SwimEntry> swimEntry = swimEvent.SwimEntries.ToList();
            int total = swimEntry.Count();
            int heatNumbers = (total + poolLanes - 1) / poolLanes;

            List<SwimEntry> shuffled = swimEntry.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < shuffled.Count; i++)
            {
                shuffled[i].HeatNumber = (byte)((i / poolLanes) + 1);
                shuffled[i].LaneNumber = (byte)((i % poolLanes) + 1);
            }
            return heatNumbers;
        }
    }
}
