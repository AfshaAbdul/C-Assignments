using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class StationRepository : IStationRepository
    {
        private IDbConnection db;
        public StationRepository(string connString)
        {
            this.db = new SqlConnection(connString);
        }


        public Station Add(Station station)
        {
            var sql =
                "INSERT INTO station (stationName)Values(@stationName)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, station).Single();
            return station;
        }


        public Station Find(int stationId)
        {
            throw new System.NotImplementedException();
        }

        public List<Station> GetAll()
        {
            return this.db.Query<Station>("SELECT * FROM station").ToList();
        }

       


        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Station Update(Station station)
        {
            throw new System.NotImplementedException();
        }


       
    }
}

