using System.Collections.Generic;

namespace DataLayer
{
    public interface IStationRepository
    {
        Station Find(int id);
        List<Station> GetAll();
        Station Add(Station station);
        Station Update(Station station);
        void Remove(int id);
      
    }
}

