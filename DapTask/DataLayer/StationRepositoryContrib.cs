using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DataLayer
{
    public class StationRepositoryContrib : IStationRepository
    {
        private IDbConnection db;
        public StationRepositoryContrib(string connString)
        {
            this.db = new SqlConnection(connString);
        }
        public Station Add(Station station)
        {
            throw new NotImplementedException();
        }

        public Station Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Station> GetAll()
        {
            throw new NotImplementedException();
        }

        public Station GetAllTrainsWithStation()
        {
            throw new NotImplementedException();
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Station Update(Station station)
        {
            throw new NotImplementedException();
        }
    }
}
