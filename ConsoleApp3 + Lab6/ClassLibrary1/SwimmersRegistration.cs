
using System.Globalization;
using ClassLibrary1;

namespace VanThanhNguyen_301377362_Lab4_5_Lib
{
    public static class SwimmersRegistration
    {
        private const string DefaultRegistrationFolder = "registrationData\\";
        private static Meet meet;

        private static byte ageToAgeGroup(byte age)
        {
            if (age <= 10) return 10;
            if (age <= 12) return 11;
            if (age <= 14) return 13;
            return 15;
        }
        private static void ProcessClubRegistrationFile(string path)
        {
            string clubName = Path.GetFileNameWithoutExtension(path);

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    ProcessSwimmerRecord(line, clubName);
                }
            }
        }
        private static void ProcessSwimmerRecord(string swimmerRecord, string clubName)
        {
            string[] fields = swimmerRecord.Split(',');
            if (fields.Length < 4) return;

            int id = int.Parse(fields[0].Trim('"'));
            string name = fields[1].Trim('"');
            DateTime birthday = DateTime.Parse(fields[2].Trim('"'));
            Sex sex = Enum.Parse<Sex>(fields[3].Trim('"'));

            Swimmer swimmer = new Swimmer(id, birthday, clubName, sex)
            {
                Name = name,
            };
            byte ageGroup = ageToAgeGroup(swimmer.Age);

            for (int i = 4; i + 2 < fields.Length; i += 3)
            {
                Stroke stroke = Enum.Parse<Stroke>(fields[i].Trim('"'));
                int distance = int.Parse(fields[i + 1].Trim('"'));
                TimeSpan seedTime = TimeSpan.ParseExact(fields[i + 2].Trim('"'), @"mm\:ss\.ff", CultureInfo.InvariantCulture);


                SwimEvent events = meet.GetEvent(stroke, distance, sex, ageGroup);
                if (events == null)
                {
                    Console.WriteLine($"Swim Event does not exist for record \"{swimmerRecord}\" in {clubName} club");
                    continue;
                }
                SwimEntry swimEntry = new SwimEntry(swimmer, events, seedTime);
                events.AddSwimEntry(swimEntry);
            }

        }
        public static void RegisterSwimmers(Meet m)
        {
            meet = m;
            if (!Directory.Exists(DefaultRegistrationFolder)) return;
            foreach (string file in Directory.GetFiles(DefaultRegistrationFolder, "*.txt"))
                ProcessClubRegistrationFile(file);

        }
    }
}
