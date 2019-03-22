using BackendApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Data
{
    public class RecordsContext : DbContext
    {
        
        public DbSet<Record> Records { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecordsDb;
                    Integrated Security=True;Connect Timeout=30;Encrypt=False;
                    TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False"
                );
        }
    }
}
