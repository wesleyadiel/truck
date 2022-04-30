using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataDBContext : DbContext
    {
        public DataDBContext() : base()
        { 
        
        }

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Caminhao> Caminhoes { get; set; }
    }
}
