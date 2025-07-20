using ClassLibrary1;

namespace ConsoleApp3___Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwimMeetPlanningService swimMeetPlanningService = new SwimMeetPlanningService(25, 8);
            Meet meet = swimMeetPlanningService.Meet;

            SwimMeetPlanningService swimMeetPlanningService2 = new SwimMeetPlanningService(25, 6);

            SwimEvent event10UX = new SwimEvent(Stroke.Breaststroke, 100, Gender.Mixed, 10); // 10&u mixed
            SwimEvent event11X = new SwimEvent(Stroke.Breaststroke, 100, Gender.Mixed, 11); // 11 mixed
            SwimEvent event13X = new SwimEvent(Stroke.Breaststroke, 100, Gender.Mixed, 13); // 13 mixed

            meet.AddEvent(event10UX);
            meet.AddEvent(event11X);
            meet.AddEvent(event13X);

            Console.WriteLine(meet);

            swimMeetPlanningService2.RegisterSwimmers();

            Console.WriteLine(meet);

            swimMeetPlanningService2.ExportEvents(@"events.json");
            meet.SeedingService = new TimeFinalSeedingService(meet);
            meet.GenerateHeatSheet("HeatSheetTimedFinals.txt");

            meet.SeedingService = new RandomSeedingService(meet);
            meet.GenerateHeatSheet("HeatSheetRandom1.txt");
            meet.GenerateHeatSheet("HeatSheetRandom2.txt");
        }
    }
}
