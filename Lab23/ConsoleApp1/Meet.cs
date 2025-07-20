namespace ConsoleApp1
{
    internal class Meet
    {
        private List<SwimEvent> events;
        private static Meet instance;

        public byte PoolLanes { get; set; }
        public int PoolLength { get; set; }

        public void AddEvent(SwimEvent swimEvent)
        {
            events.Add(swimEvent);
        }
        public static Meet CreateMeet(int poolLength, byte poolLanes)
        {
            if (instance == null)
            {
                instance = new Meet();
            }
            instance.PoolLanes = poolLanes;
            instance.PoolLength = poolLength;
            instance.events = new List<SwimEvent>();
            return instance;
        }
        private Meet()
        {
            List<SwimEvent> events = new List<SwimEvent>();
        }
        public override string ToString()
        {
            string result = $"Meet : Pool length = {PoolLanes}m, Lanes = {PoolLength}m\n";
            foreach (SwimEvent swimEvent in events)
            {
                result += swimEvent.ToString() + "\n";
            }
            return result;
        }
    }
}
