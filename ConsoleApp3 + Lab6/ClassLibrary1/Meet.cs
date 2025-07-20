namespace ClassLibrary1
{
    public class Meet
    {
        public List<SwimEvent> events;
        private static Meet? instance;

        public List<SwimEvent> Events { get; }
        public byte PoolLanes { get; set; }
        public int PoolLength { get; set; }
        public SeedingService SeedingService
        {
            set
            {
                //SeedingService = value;
                foreach (SwimEvent swimEvent in events)
                {
                    swimEvent.seedingService = value;  
                }
            }
        }
        public void AddEvent(SwimEvent swimEvent)
        {
            events.Add(swimEvent);
        }
        public static Meet CreateMeet(int poolLength, byte poolLanes)
        {
            if (instance == null)
            {
                instance = new Meet();
                instance.PoolLength = poolLength;
                instance.PoolLanes = poolLanes;
            }
            return instance;
        }
        public void GenerateHeatSheet(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (SwimEvent swimEvent in events)
            {
                if (swimEvent.seedingService != null)
                    swimEvent.GenerateEventHeatSheet(writer);
            }
        }
        public SwimEvent GetEvent(Stroke stroke, int distance, Sex sex, byte ageGroup)
        {
            foreach (SwimEvent swimEvent in events)
            {
                if (swimEvent.Stroke == stroke &&
                    swimEvent.Distance == distance &&
                    swimEvent.AgeGroup == ageGroup &&
                    (swimEvent.Gender == Gender.Mixed ||
                     swimEvent.Gender.ToString() == sex.ToString()))
                {
                    return swimEvent;
                }
            }
            return null;
        }
        private Meet()
        {
            events = new List<SwimEvent>();
        }
        public override string ToString()
        {
            string result = $"Meet : Pool Length = {PoolLength}m, Lanes = {PoolLanes}m\n";
            foreach (SwimEvent swimEvent in events)
            {
                result += swimEvent.ToString() + "\n";
            }
            return result;
        }
    }
}
