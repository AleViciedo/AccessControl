using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        #region Tables

        public DbSet<Person> Persons { get; set; }

        #endregion

        public ApplicationContext()
        {
        }

        //public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        //{
        //}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
