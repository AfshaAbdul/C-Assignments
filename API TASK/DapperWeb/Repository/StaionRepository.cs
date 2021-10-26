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

        public async Task<Stations> AddStationDetails(Stations station)
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
                    param.Add("@ENDTIME", station.Departure_Time);
                    param.Add("@OPERATINGDAYS", station.Operation_Days);
                    param.Add("@OPERATINGDATE", station.Operating_Date);
                    var result = await con.QueryAsync<Stations>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stations> RemoveStationDetails(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "C");
                    param.Add("@STATIONID", id);
                    var result = await con.QueryAsync<Stations>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stations>> FetchStationDetialsByID(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "D");
                    param.Add("@STATIONID", id);
                    var result = await con.QueryAsync<Stations>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stations>> FetchAllStationsDetails()
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

        public async Task<List<Stations>> FetchTrainsInStationByTime(int id, string time)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "E");
                    param.Add("@STATIONID", id);
                    param.Add("@ARRTIME", time);
                    var result = await con.QueryAsync<Stations>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stations>> FetchTrainsInStationByDate(int id, string date)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "F");
                    param.Add("@STATIONID", id);
                    param.Add("@OPERATINGDATE", date);
                    var result = await con.QueryAsync<Stations>(sQuery, param, commandType: CommandType.StoredProcedure);
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
