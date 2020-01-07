namespace DoggyDayCare.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class DoggyDayCareDbContext : DbContext
    {
        public DoggyDayCareDbContext(DbContextOptions<DoggyDayCareDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.HasDefaultSchema("DoggyDayCare");  // Specify schema

            b.Entity<Student>()
                .HasMany(s => s.Dogs)            // Student has many dogs
                .WithOne(d => d.Owner)           // Dogs have one owner (i.e. Student)
                .HasForeignKey(d => d.OwnerId);  // Specify the foreign key on the dog entity

            b.Entity<Dog>()
                .HasMany(d => d.TimeSheets)     // Dog has many timesheets
                .WithOne(t => t.Dog)            // Timesheets belong to one dog
                .HasForeignKey(t => t.DogId);   // Specify the foreign key on the timesheet entity

            // Tell database to use decimal for TotalPaid
            b.Entity<TimeSheet>()
                .Property(t => t.TotalPaid)
                .Metadata
                .SetColumnType("decimal(18, 2)");

            // Tell database to use decimal for TotalCharged
            b.Entity<TimeSheet>()
                .Property(t => t.TotalCharged)
                .Metadata
                .SetColumnType("decimal(18, 2)");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
    }
}