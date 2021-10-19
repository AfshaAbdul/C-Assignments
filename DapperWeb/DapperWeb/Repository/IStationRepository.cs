using DapperWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repository
{
    public interface IStationRepository
    {
        Task<List<Stations>> GetStations();
        Task<Stations> GetStationByID(int id);
        Task<Stations> ADDEditStation(Stations station);
        Task<Stations> DeleteStation(int id);
    }
}
