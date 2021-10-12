using System.Collections.Generic;

namespace DataLayer
{
    public interface ITrainRepository
    {
        Train Find(int id);
        List<Train> GetAll();
        Train Add(Train train);
        Train Update(Train train);
        void Remove(int id);
    }
}

