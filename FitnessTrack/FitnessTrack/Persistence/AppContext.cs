using FitnessTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FitnessTrack.Persistence
{
    public class AppContext : DbContext
    {

        private const string _dbName = "fitnesstrack.db";

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseSpecification> ExerciseSpecifications { get; set; }

        public AppContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, _dbName);
            

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
