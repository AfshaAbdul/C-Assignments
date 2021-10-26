using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperWeb.Repository;
using DapperWeb.Models;
namespace DapperWeb.Controllers
{
    [Route("api/Station")]
    [ApiController]
    public class StationController : Controller
    {
        private readonly IStationRepository _stationRep;
        public StationController(IStationRepository stationRepository)
        {
            _stationRep = stationRepository;
        }

        // GET api/values
        [Route("FetchStations")]
        [HttpGet]
        public async Task<List<Stations>> FetchAllStationsDetails()
        {
            try
            {
                return await _stationRep.FetchAllStationsDetails();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("AddStation")]
        [HttpPost]
        public async Task<ActionResult<Stations>> AddStationDetails([FromBody] Stations station)
        {
            if (station == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }
            //var at = TimeSpan.Parse(station.Arrival_Time);
            //TimeSpan Arrival_tme = TimeSpan.Parse("12:00:00");
            return await _stationRep.AddStationDetails(station);
        }
        [Route("RemoveStation/{Id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stations>> RemoveStationDetails(int id)
        {
            try
            {
                return await _stationRep.RemoveStationDetails(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [Route("FetchStationById/{id}")]
        [HttpGet("{id}")]
        public async Task<List<Stations>> FetchStationDetialsByID(int id)
        {
            try
            {
                return await _stationRep.FetchStationDetialsByID(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [Route("FetchTrainsByTime/{id}/{time}")]
        [HttpGet]
        public async Task<List<Stations>> FetchTrainsInStationByTime(int id,string time)
        {
            try
            {
                return await _stationRep.FetchTrainsInStationByTime(id,time);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("FetchTrainsByDate/{id}/{date}")]
        [HttpGet]
        public async Task<List<Stations>> FetchTrainsInStationByDate(int id, string date)
        {
            try
            {
                return await _stationRep.FetchTrainsInStationByDate(id, date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

        

      
       
}