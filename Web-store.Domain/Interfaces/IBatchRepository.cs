using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IBatchRepository
    {
        Batch Add(Batch patch);
        List<Batch> GetAll();
        Batch GetById(int id);
        bool removeById(int id);
        Batch Update(Batch patch);

    }
}
