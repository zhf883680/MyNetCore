using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Services
{
    public interface IRepository<T> where  T:class
    {
        IEnumerable<T> GetAll();
    }
}
