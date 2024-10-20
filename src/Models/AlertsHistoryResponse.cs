using IsraelHomeFrontCommandAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelHomeFrontCommandAPI.Models
{
    public class AlertHistoryResponse
    {
        public DateTime AlertDateIst {  get; set; }

        public AlertType AlertType { get; set; }

        public string? City { get; set; }
    }
}
