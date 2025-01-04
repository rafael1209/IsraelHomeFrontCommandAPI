using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_En { get; set; }
        public string Name_Ru { get; set; }
        public string Name_Ar { get; set; }
        public string Zone { get; set; }
        public string ZoneEn { get; set; }
        public string Zone_Ru { get; set; }
        public string Zone_Ar { get; set; }
        public int Countdown { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Value { get; set; }
    }
}
