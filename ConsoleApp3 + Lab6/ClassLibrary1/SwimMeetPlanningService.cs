using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VanThanhNguyen_301377362_Lab4_5_Lib;


namespace ClassLibrary1
{
    public class SwimMeetPlanningService
    {
        private const string DefaultEventFile = "data\\events.json";
        public Meet Meet { get; set; }
        public void ExportEvents(string path)
        {
            string json = JsonSerializer.Serialize(Meet.Events, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            Console.WriteLine($"File created : {Path.GetFullPath(path)}");
            Console.WriteLine("File created events.json");
        }
        public void ImportEvents(string path)
        {
            if (!File.Exists(path)) return;
            string json = File.ReadAllText(path);
            List<SwimEvent>? importedEvent = JsonSerializer.Deserialize<List<SwimEvent>>(json);

            if (importedEvent != null)
            {
                if (Meet?.Events != null)
                {
                    Meet.Events.Clear();
                }
                foreach (SwimEvent swimEvent in importedEvent)
                {
                    Meet.AddEvent(swimEvent);
                }
                SwimEvent.SetEventsNoAfterLoad(importedEvent.Count);
            }
        }
        public void RegisterSwimmers(string? path = null)
        {
            SwimmersRegistration.RegisterSwimmers(Meet);
        }
        public SwimMeetPlanningService(int poolLength, byte poolLanes)
        {
            Meet = Meet.CreateMeet(poolLength, poolLanes);
            if (File.Exists(DefaultEventFile))
            {
                ImportEvents(DefaultEventFile);
            }
            else
            {
                Console.WriteLine($"Default event file not found: {DefaultEventFile}");
            }
        }
    }
}
