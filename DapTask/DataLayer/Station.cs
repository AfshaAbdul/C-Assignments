using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class Station
    {
        public int Id { get; set; }
        public string stationName { get; set; }

       
        //public bool IsNew => this.Id == default(int);
        public List<Train> Train { get; } = new List<Train>();
    }
}

