using lab8.Models;
using System.Collections.Generic;

namespace lab8.Data
{
    public interface IFoxesRepository
    {
        void Add(Fox f);
        Fox Get(int id);
        IEnumerable<Fox> GetAll();
        void Update(int id, Fox f);
    }
}
