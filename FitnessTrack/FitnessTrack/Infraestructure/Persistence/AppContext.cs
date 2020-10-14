using System.IO;
using FitnessTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrack.Infraestructure.Persistence
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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, _dbName);
            

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
