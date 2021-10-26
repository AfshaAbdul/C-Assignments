using DapperWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DapperWeb.Repository
{
   public  interface ITrainRepository
    {
        Task<List<Trains>> GetStationsList(int id);
        Task<List<Trains>> FetchStationByTrainTimeDate(int id, string time,string date);
        Task<List<Trains>> FetchStationByTrainIdDate(int id, string date);
        Task<ActionResult<Trains>> RemoveTrainDetails(int id);
    }
}
