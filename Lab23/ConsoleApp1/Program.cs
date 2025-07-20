using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Swimmer swimmer1 = new Swimmer(1, new DateTime(2025 - 9, 1, 1), "John Doe", Sex.Male) { Club = "Sharks"};
            Swimmer swimmer4 = new Swimmer(4, new DateTime(2025 - 8, 1, 1), "Anna Kim", Sex.Male) { Club = "Barracudas" };
            Swimmer swimmer5 = new Swimmer(5, new DateTime(2025 - 10, 1, 1), "Emily Clark", Sex.Male) { Club = "Otters" };
            Swimmer swimmer6 = new Swimmer(6, new DateTime(2025 - 10, 1, 1), "Liam Brown", Sex.Male) { Club = "Sharks" };

            Swimmer swimmer2 = new Swimmer(2, new DateTime(2025 - 11, 1, 1), "Jane Smith", Sex.Female) { Club = "Dolphins" };
            Swimmer swimmer3 = new Swimmer(3, new DateTime(2025 - 12, 1, 1), "Mike Lee", Sex.Female) { Club = "Sharks" };
            Swimmer swimmer7 = new Swimmer(7, new DateTime(2025 - 12, 1, 1), "Noah Evans", Sex.Female) { Club = "Otters" };
            Swimmer swimmer8 = new Swimmer(8, new DateTime(2025 - 11, 1, 1), "Sophia Park", Sex.Female) { Club = "Barracudas" };

            Console.WriteLine("Meet Details:");
            Meet meet = Meet.CreateMeet(25, 8);

            SwimEvent swimEvent1 = new SwimEvent( Stroke.Freestyle, 50, Gender.Male, 10);
            SwimEvent swimEvent2 = new SwimEvent(Stroke.Backstroke, 50, Gender.Female, 12);

            meet.AddEvent(swimEvent1);
            meet.AddEvent(swimEvent2);

            TimeOnly seedTime1 = TimeOnly.Parse("00:00:45.02");
            TimeOnly seedTime5 = TimeOnly.Parse("00:00:46.01");
            TimeOnly seedTime6 = TimeOnly.Parse("00:00:47.05");
            TimeOnly seedTime4 = TimeOnly.Parse("00:00:48.057");

            SwimEntry swimEntry1 = new SwimEntry(swimmer1, swimEvent1, seedTime1);
            SwimEntry swimEntry5 = new SwimEntry(swimmer5, swimEvent1, seedTime5);
            SwimEntry swimEntry6 = new SwimEntry(swimmer6, swimEvent1, seedTime6);
            SwimEntry swimEntry4 = new SwimEntry(swimmer4, swimEvent2, seedTime4);

            swimEvent1.AddSwimEntry(swimEntry1);
            swimEvent1.AddSwimEntry(swimEntry5);
            swimEvent1.AddSwimEntry(swimEntry6);
            swimEvent1.AddSwimEntry(swimEntry4);

            TimeOnly seedTime3 = TimeOnly.Parse("00:00:41.09");
            TimeOnly seedTime2 = TimeOnly.Parse("00:00:42.01");
            TimeOnly seedTime7 = TimeOnly.Parse("00:00:43.02");
            TimeOnly seedTime8 = TimeOnly.Parse("00:00:44.08");

            SwimEntry swimEntry2 = new SwimEntry(swimmer2, swimEvent2, seedTime2);
            SwimEntry swimEntry3 = new SwimEntry(swimmer3, swimEvent2, seedTime3);
            SwimEntry swimEntry7 = new SwimEntry(swimmer7, swimEvent2, seedTime7);
            SwimEntry swimEntry8 = new SwimEntry(swimmer8, swimEvent2, seedTime8);

            swimEvent2.AddSwimEntry(swimEntry2);
            swimEvent2.AddSwimEntry(swimEntry3);
            swimEvent2.AddSwimEntry(swimEntry7);
            swimEvent2.AddSwimEntry(swimEntry8);

            Console.WriteLine("Swimmer : ");
            Console.WriteLine(swimmer1);
            Console.WriteLine(swimmer2);
            Console.WriteLine(swimmer3);
            Console.WriteLine(swimmer4);
            Console.WriteLine(swimmer5);
            Console.WriteLine(swimmer6);
            Console.WriteLine(swimmer7);
            Console.WriteLine(swimmer8);

            Console.WriteLine();
            Console.WriteLine("\nSwim Events:");
            Console.WriteLine(swimEvent1);
            Console.WriteLine();
            Console.WriteLine(swimEvent2);
            Console.WriteLine();
            Console.WriteLine("Meet Details: ");
            Console.WriteLine(meet);
        }
    }
}
