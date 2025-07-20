using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Swimmer
    {
        public byte Age { get; }
        public DateTime BDay { get; }
        public string Club { get; set; }
        public int Id { get; }
        public string Name { get; set; }
        public Sex Sex { get; }

        public Swimmer(int id, DateTime bDay, string club, Sex sex)
        {
            Id = id;
            BDay = bDay;
            Club = club;
            Sex = sex;
        }
        public override string ToString()
        {
            int age = DateTime.Now.Year - BDay.Year;
            return $"{Id,-5} {Name,-18} {Sex,-10} {age,-3}";
        }
    }
}
