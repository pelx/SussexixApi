using BackendApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Services
{
    public interface IRecordsService 
    {
        IEnumerable<Record> GetAll();
        Record Save(Record record);
        Record Update(int id, Record record);
    }
}
