using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SwimEntry
    {
        public SwimEvent Event { get; set; }
        public byte HeatNumber {get; set; }
        public byte LaneNumber { get; set; }
        public TimeOnly Result { get; set; }
        public TimeOnly SeedTime { get; set; }
        public Swimmer Swimmer { get; set; }

        public SwimEntry(Swimmer swimmer, SwimEvent swimEvent, TimeOnly seedtime)
        {
            Swimmer = swimmer;
            Event = swimEvent;
            SeedTime = seedtime;
        }
        public override string ToString()
        {
            int age = DateTime.Now.Year - Swimmer.BDay.Year;
            return $"{Swimmer.Id,-4}{Swimmer.Name,-20} {Swimmer.Sex,-7} {age,-6} {Swimmer.Club,-15} {SeedTime:mm\\:ss\\.ff}";
        }
    }
}
