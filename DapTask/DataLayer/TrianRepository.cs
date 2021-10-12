using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class TrianRepository : ITrainRepository
    {
        private IDbConnection db;
        public TrianRepository(string connString)
        {
            this.db = new SqlConnection(connString);
        }


        public Train Add(Train train)
        {
            throw new System.NotImplementedException();
        }

        public Train Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Train> GetAll()
        {
            return this.db.Query<Train>("SELECT * FROM Trains").ToList(); 
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Train Update(Train train)
        {
            throw new System.NotImplementedException();
        }
    }
}


