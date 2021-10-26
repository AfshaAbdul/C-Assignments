using DapperWeb.Models;
using DapperWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Controllers
{
    [Route("api/Train")]
    [ApiController]
    public class TrainController : Controller
    {
        private readonly ITrainRepository _trainRep;
        public TrainController(ITrainRepository trainRepository)
        {
            _trainRep = trainRepository;
        }


        [Route("FetchStationByTrainId/{id}")]
        [HttpGet("{id}")]
        public async Task<List<Trains>> GetStationsList(int id)
        {
            try
            {
                return await _trainRep.GetStationsList(id);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
        [Route("FetchStationByTrainTimeDate/{id}/{time}/{date}")]
        [HttpGet]
        public async Task<List<Trains>> FetchStationByTrainTimeDate(int id, string time,string date)
        {
            try
            {
                return await _trainRep.FetchStationByTrainTimeDate(id, time,date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("FetchStationByTrainIdDate/{id}/{date}")]
        [HttpGet]
        public async Task<List<Trains>> FetchStationByTrainIdDate(int id, string date)
        {
            try
            {
                return await _trainRep.FetchStationByTrainIdDate(id,date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("RemoveTrain/{Id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trains>> RemoveTrainDetails(int id)
        {
            try
            {
                return await _trainRep.RemoveTrainDetails(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
