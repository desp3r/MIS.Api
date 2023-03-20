using Microsoft.EntityFrameworkCore;
using MIS.Data.Models;

namespace MIS.Data.Contexts
{
    public class MisContext : DbContext
    {
        public MisContext(DbContextOptions<MisContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Timeslot> Timeslots { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
