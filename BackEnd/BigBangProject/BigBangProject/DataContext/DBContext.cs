using BigBangProject.Model;
using Microsoft.EntityFrameworkCore;

namespace BigBangProject.DataContext
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DaySchedule> DaySchedules { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Meals> Mealss { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<SightSeeing> SightSeeings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
