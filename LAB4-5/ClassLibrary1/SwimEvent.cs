using System;

namespace ClassLibrary1
{
    public class SwimEvent
    {
        private ushort eventNumber;
        private static ushort eventsNo;
        private List<SwimEntry> swimEntries;

        public byte AgeGroup { get; set; }
        public int Distance { get; set; }
        public Gender Gender { get; set; }
        public Stroke Stroke { get; set; }

        public void AddSwimEntry(SwimEntry swimEntry)
        {
            swimEntries.Add(swimEntry);
            swimEntry.Event = this;
        }
        public void SetEventsNoAfterLoad(ushort value)
        {
            eventsNo = value;
        }
        public SwimEvent()
        {
            eventNumber = ++eventsNo;
            swimEntries = new List<SwimEntry>();
        }
        public SwimEvent(Stroke stroke, int distance, Gender gender, byte age) : this()
        {
            Stroke = stroke;
            Distance = distance;
            Gender = gender;
            AgeGroup = age;
        }
        public override string ToString()
        {
            string result = $"Event: #{eventNumber} {Distance}m {Stroke} ({Gender}), Age Group: {AgeGroup}\n";
            result += "#  ID   Name               Sex      Age     Club          Seed Time\n";

            for (int i = 0; i < swimEntries.Count; i++)
            {
                result += $"{i + 1,-3}{swimEntries[i].ToString()}\n";
            }
            return result;
        }

        public static void SetEventsNoAfterLoad(int count)
        {
            count = (ushort)count;
        }
    }
}
