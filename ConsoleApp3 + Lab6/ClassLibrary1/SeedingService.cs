
namespace ClassLibrary1
{
    public abstract class SeedingService
    {
        protected readonly byte middleLane;
        protected readonly byte poolLanes;

        public abstract int SeedEvent(SwimEvent swimEvent);
        protected SeedingService(Meet meet)
        {
            poolLanes = meet.PoolLanes;
            middleLane = (byte)((poolLanes + 1) / 2);
        }


    }
}
