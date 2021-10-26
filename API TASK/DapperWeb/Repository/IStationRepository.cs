using DapperWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repository
{
    public interface IStationRepository
    {
        Task<List<Stations>> FetchAllStationsDetails();
        Task<List<Stations>> FetchStationDetialsByID(int id);
        Task<Stations> AddStationDetails(Stations station);
        Task<Stations> RemoveStationDetails(int id);
        Task<List<Stations>>FetchTrainsInStationByTime(int id,string time);
        Task<List<Stations>> FetchTrainsInStationByDate(int id, string date);

    }
}
