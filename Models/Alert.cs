using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class Alert
    {
        public string Id { get; set; }
        public string Cat { get; set; }
        public string Title { get; set; }
        public List<string> Data { get; set; }
        public string Desc { get; set; }
    }
}
