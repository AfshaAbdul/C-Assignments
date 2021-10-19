using Dapper;
using DapperWeb.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repository
{
    public class StationRepository : IStationRepository

    {
        private readonly IConfiguration _config;
        public StationRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<Stations> ADDEditStation(Stations station)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "B");
                    param.Add("@STATIONID", station.StationId);
                    param.Add("@STATIONNAME", station.StationName);
                    param.Add("@TRAINID", station.TrainId);
                    param.Add("@TRAINNAME", station.TrainName);
                    param.Add("@ARRTIME", station.Arrival_Time);
                    param.Add("@ENDTIME", station.End_Time);
                    param.Add("@OPERATINGDAYS", station.Operation_Days);
                    var result = await con.QueryAsync<Stations>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Stations> DeleteStation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Stations> GetStationByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Stations>> GetStations()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "A");
                    var result = await con.QueryAsync<Stations>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


    }
}
