using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Models
{
    public class Stations
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public TimeSpan Arrival_Time { get; set; }
        public TimeSpan End_Time { get; set; }
        public string Operation_Days { get; set; }
    }
}
