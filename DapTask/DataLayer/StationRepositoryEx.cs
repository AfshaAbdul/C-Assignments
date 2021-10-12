using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataLayer
{
    public class StationRepositoryEx
    {
        private IDbConnection db;

        public StationRepositoryEx(string connString)
        {
            this.db = new SqlConnection(connString);
        }


        public List<Station> GetAllTrainsWithStation()
        {
            var sql = "SELECT * FROM station AS C INNER JOIN Trains AS A ON A.stationId = C.Id";

            var stationDict = new Dictionary<int, Station>();

            var station = this.db.Query<Station, Train, Station>(sql, (station, train) =>
            {
                if (!stationDict.TryGetValue(station.Id, out var currentStation))
                {
                    currentStation = station;
                    stationDict.Add(currentStation.Id, currentStation);
                }

                currentStation.Train.Add(train);
                return currentStation;
            });
            return station.Distinct().ToList();

        }

    }
    }

