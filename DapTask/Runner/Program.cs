using DataLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Runner
{
    class Program
    {
        private static IConfigurationRoot config;
        static void Main(string[] args)
        {
            Initialize();
            //Get_all_should_return_6_results();
            var id = Insert_should_assign_identity_to_new_entity();


            Get_all_should_return_4_results_with_trains();


        }
        static int Insert_should_assign_identity_to_new_entity()
        {
            // arrange
            IStationRepository repository = CreateRepository();
            var station = new Station
            {
                Id = 8,
                stationName = "Puri",
               
            };
            var trains = new Train
            {
                TrainName = "dwaraka express",
                //start_time = 12:00:00,
                //end_time = 12:30:00,
                OperatingDays = "Daily"
                
            };
            station.Train.Add(trains);

            // act
            repository.Add(station);
            //repository.Save(station);

            // assert
            Debug.Assert(station.Id != 0);
            Console.WriteLine("*** station Inserted ***");
            Console.WriteLine($"New ID: {station.Id}");
            return station.Id;
        }



        static void Get_all_should_return_4_results_with_trains()
        {
            var repository = CreateRepositoryEx();

            // act

            var station = repository.GetAllTrainsWithStation();

            // assert
            Console.WriteLine($"Count: {station.Count}");
            station.Output();
            Debug.Assert(station.Count == 7);
            Debug.Assert(station.First().Train.Count == 2);
        }

        
        static void Get_all_should_return_6_results()
        {
            //arrange
            var repository = CreateRepository();
            //var repository2 = CreateRepository();
            //act
            var stations = repository.GetAll();
            //var train = repository2.GetAll();
            //assert
           
            Debug.Assert(stations.Count == 6);
           // Debug.Assert(train.Count == 6);
            stations.Output();
        }
        private static void Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }
        private static IStationRepository CreateRepository()
        {
            return new StationRepository("Server =(LocalDb)\\MSSQLLocalDB;Database=Enquery;Trusted_Connection = True;MultipleActiveResultSets=true");
        }
        private static StationRepositoryEx CreateRepositoryEx()
        {
            return new StationRepositoryEx("Server =(LocalDb)\\MSSQLLocalDB;Database=Enquery;Trusted_Connection = True;MultipleActiveResultSets=true");
        }
    }
}
