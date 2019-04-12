using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovie.Models;

namespace MyMovie.Services
{
    public class InMemoryRepository : IRepository<Models.Student>
    {
        public IEnumerable<Models.Student> GetAll()
        {
            return new List<Student>()
            {
                new Student()
                {
                    age = 1,
                    Name = "zhf"
                },
                new Student()
                {
                    age = 1,
                    Name = "zhf"
                },
                new Student()
                {
                    age = 1,
                    Name = "zhf"
                }
            };
        }
    }
}
