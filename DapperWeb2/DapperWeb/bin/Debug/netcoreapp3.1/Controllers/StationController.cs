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
        [Route("get")]
        [HttpGet]
        public async Task<List<Stations>> GetStations()
        {
            try
            {
                return await _stationRep.GetStations();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [Route("get/trains/{Id}")]
        [HttpGet]
        //public async Task<ActionResult<Stations>> GetAllTrainsInStation(int id)
        //{
        //    try
        //    {
        //        return await _stationRep.GetAllTrainsInStation(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [Route("Addedit")]
        [HttpPost]
        public async Task<ActionResult<Stations>> ADDEditStation([FromBody] Stations station)
        {
            if (station == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }
            //var at = TimeSpan.Parse(station.Arrival_Time);
            //TimeSpan Arrival_tme = TimeSpan.Parse("12:00:00");
            return await _stationRep.ADDEditStation(station);
        }
        [Route("del/{Id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stations>> DeleteById(int id)
        {
            try
            {
                return await _stationRep.DeleteStation(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [Route("Get/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Stations>> GetByStationByID(int id)
        {
            try
            {
                return await _stationRep.GetStationByID(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

        

      
       
}