using AdsProyect.BussinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.DataAccessLogic
{
    public class ContextoDB : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Ad> Ad { get; set; }
        public DbSet<AdImage> AdImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = localhost;
                                                Initial Catalog = AdsProyect
                                                User Id = Jeffrey;
                                                Pwd = jeffrey20068f;
                                                Encrypt = false
                                                TrustServerCertificate = true");
        }
    }
}
