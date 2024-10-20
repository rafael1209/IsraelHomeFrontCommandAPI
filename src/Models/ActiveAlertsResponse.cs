using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsraelHomeFrontCommandAPI.Enums;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class ActiveAlertsResponse
    {
        public AlertType AlertType { get; set; }

        public List<string>? Cities { get; set; }

        public string? Instructions { get; set; }
    }
}
