using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal struct SwimEvent
    {
        public byte AgeGroup;
        public int Distance;
        private static ushort eventNumber;
        public ushort EventNumber;
        public Gender Gender;
        public Stroke Stroke;
        private List<SwimEntry> swimEntries;

        public void AddSwimEntry(SwimEntry swimEntry)
        {
            swimEntries.Add(swimEntry);
        }
        public SwimEvent(Stroke stroke, int distance, Gender gender, byte age)
        {
            Stroke = stroke;
            Distance = distance;
            Gender = gender;
            AgeGroup = age;
            EventNumber = ++eventNumber;
            swimEntries = new List<SwimEntry>();
        }
        public override string ToString()
        {
            string result = $"Event: #{EventNumber} {Distance}m {Stroke} ({Gender}), Age Group: {AgeGroup}\n";
            result +="#  ID   Name               Sex      Age     Club          Seed Time\n";

            for (int i = 0; i < swimEntries.Count; i++)
            {
                result += $"{i + 1,-3}{swimEntries[i].ToString()}\n";
            }
            return result;
        }
    }
}
