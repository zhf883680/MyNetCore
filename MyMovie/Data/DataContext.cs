using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMovie.Models;

namespace MyMovie.Data
{
    //手动创建EF
    public class DataContext:DbContext
    {
        //ctor 快速创建构造函数
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
    
}
