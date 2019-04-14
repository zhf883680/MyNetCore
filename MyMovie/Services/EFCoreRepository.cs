using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovie.Data;
using MyMovie.Models;

namespace MyMovie.Services
{
    public class EFCoreRepository:IRepository<Student>
    {
        private readonly DataContext _context;

        public EFCoreRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public int Add(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return student.No;
        }

        public Student Get(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
