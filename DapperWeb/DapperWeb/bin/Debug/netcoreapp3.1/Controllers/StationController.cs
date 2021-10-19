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
        [Route("")]
        [HttpGet]
        public async Task<List<Stations>> GetStations()
        {
            return await _stationRep.GetStations();
        }

        [Route("Addedit")]
        [HttpPost]
        public async Task<ActionResult<Stations>> ADDEditStation([FromBody] Stations station)
        {
            if (station == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }
            //var at = TimeSpan.Parse(station.Arrival_Time);
            return await _stationRep.ADDEditStation(station);
        }
    }

        

      
       
}