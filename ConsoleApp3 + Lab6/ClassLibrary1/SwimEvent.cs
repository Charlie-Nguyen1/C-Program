using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SwimEvent
    {
        private ushort eventNumber;
        private static ushort eventsNo;
        private int numberOfHeats;
        public SeedingService seedingService;
        private List<SwimEntry> swimEntries = new List<SwimEntry>();

        public byte AgeGroup { get; set; }
        public int Distance { get; set; }
        public Gender Gender { get; set; }
        public Stroke Stroke { get; set; }
        public List<SwimEntry> SwimEntries { get; set; }
        public void AddSwimEntry(SwimEntry swimEntry)
        {
            swimEntries.Add(swimEntry);
            swimEntry.Event = this;
        }
        public void GenerateEventHeatSheet(StreamWriter writer)
        {
            SeedEvent();
            if (numberOfHeats == 0) return;

            writer.WriteLine($"Event: #{eventNumber} {Distance}m {Stroke} ({Gender}), Age Group: {AgeGroup}");
            foreach (var swimEntry in swimEntries)
            {
                writer.WriteLine($"Heat {swimEntry.HeatNumber}, Lane {swimEntry.LaneNumber}: {swimEntry.Swimmer}");
            }
        }
        public void SeedEvent()
        {
            if (seedingService == null)
            {
                numberOfHeats = 0;
                return;
            }
            numberOfHeats = seedingService.SeedEvent(this);
        }
        public void SetEventsNoAfterLoad(ushort value)
        {
            eventsNo = value;
        }
        public SwimEvent()
        {
            eventNumber = ++eventsNo;
            SwimEntries = new List<SwimEntry>();
            numberOfHeats = 0;
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

            if (swimEntries != null)
            {
                for (int i = 0; i < swimEntries.Count; i++)
                {
                    result += $"{i + 1,-3}{swimEntries[i].ToString()}\n";
                }
            }
            return result;
        }

        public static void SetEventsNoAfterLoad(int count)
        {
            count = (ushort)count;
        }
    }
}
