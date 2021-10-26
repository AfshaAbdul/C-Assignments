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
    
        public class ScheduleRepository : IScheduleRepository
        {
        private readonly IConfiguration _config;
        public ScheduleRepository(IConfiguration config)
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
            public async Task<List<Schedule>> FetchTrainsWithDate(string date)
            {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "I");
                    param.Add("@OPERATINGDATE", date);
                    var result = await con.QueryAsync<Schedule>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Schedule>> FetchTrainsWithTime(string time)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Stations";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "K");
                    param.Add("@ARRTIME", time);
                    var result = await con.QueryAsync<Schedule>(sQuery, param, commandType: CommandType.StoredProcedure);
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
