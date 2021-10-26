using DapperWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repository
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> FetchTrainsWithDate(string date);
        Task<List<Schedule>> FetchTrainsWithTime(string time);
    }
}
