using Dapper;
using DapperWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repository
{
    public class TrainRepository : ITrainRepository
    {
        private readonly IConfiguration _config;
        public TrainRepository(IConfiguration config)
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

        public async Task<List<Trains>> FetchStationByTrainIdDate(int id, string date)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "J");
                    param.Add("@TRAINID", id);
                    param.Add("@@OPERATINGDATE", date);
                    var result = await con.QueryAsync<Trains>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public async Task<List<Trains>> FetchStationByTrainTimeDate(int id, string time,string date)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "H");
                    param.Add("@TRAINID", id);
                    param.Add("@ARRTIME", time);
                    param.Add("@@OPERATINGDATE", date);
                    var result = await con.QueryAsync<Trains>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Trains>> GetStationsList(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "G");
                    param.Add("@TRAINID", id);
                    var result = await con.QueryAsync<Trains>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult<Trains>> RemoveTrainDetails(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "L");
                    param.Add("@TRAINID", id);
                    var result = await con.QueryAsync<Trains>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
