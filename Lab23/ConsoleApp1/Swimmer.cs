using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Swimmer
    {
        public DateTime BDay { get; }
        public string Club { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; }

        public Swimmer(int id, DateTime bDay, string name, Sex sex)
        {
            Id = id;
            Name = name;
            Sex = sex;
            BDay = bDay;
        }

        public override string ToString()
        {
            int age = DateTime.Now.Year - BDay.Year;
            return $"{Id, -5} {Name, -18} {Sex, -10} {age, -3}";
            
        }
    }
}
