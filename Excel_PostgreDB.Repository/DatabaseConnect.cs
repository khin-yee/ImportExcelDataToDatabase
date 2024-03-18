using Excel_PostgreDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Repository
{
    public  class DatabaseConnect:DbContext
    {
        public DatabaseConnect(DbContextOptions<DatabaseConnect> options) : base(options)
        {

        }
        
        public DbSet<SR> SR { get; set; }
   
        public DbSet<District> District { get; set; }
        public DbSet<Township> Township { get; set; }
        public DbSet<Town> Town { get; set; }
      
        public DbSet<Ward> Ward { get; set; }
        
    }
}
