using Nest;
using System;


namespace DataLayer
{
    public class Train
    {
        public int Id { get; set; }
        public string TrainName { get; set; }
        
       public TimeSpan start_time{ get; set; }
       public TimeSpan end_time { get; set; }
       public string OperatingDays { get; set; }
    }
}

