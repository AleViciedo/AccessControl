using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain.Entities.ConfigurationData;
using AccessControl.Domain.Entities.HistoricalData;
using AccessControl.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        #region Tables

        public DbSet<Person> Persons { get; set; }
        public DbSet<AccessEntry> AccessEntries { get; set; }
        public DbSet<Process> Processes { get; set; }

        #endregion

        public ApplicationContext()
        {
        }

        public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

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

        private static DbContextOptions GetOptions (string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

    }
}
