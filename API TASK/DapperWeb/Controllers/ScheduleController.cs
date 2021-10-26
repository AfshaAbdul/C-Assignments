using DapperWeb.Models;
using DapperWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DapperWeb.Controllers
{
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRep;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRep = scheduleRepository;
        }
        [Route("FetchTrainsListByDate/{date}")]
        [HttpGet]
        public async Task<List<Schedule>> FetchTrainsWithDate( string date)
        {
            try
            {
                return await _scheduleRep.FetchTrainsWithDate(date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("FetchTrainsListByTime/{time}")]
        [HttpGet]
        public async Task<List<Schedule>> FetchTrainsWithTime(string time)
        {
            try
            {
                return await _scheduleRep.FetchTrainsWithTime(time);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}
