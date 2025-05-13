using Microsoft.EntityFrameworkCore;

namespace server_hatde.Entities
{
    public class WeddingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VendorProfile> VendorProfiles { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Phone).IsUnique();

            modelBuilder.Entity<VendorProfile>()
                .HasOne(v => v.Vendor)
                .WithOne(u => u.VendorProfile)
                .HasForeignKey<VendorProfile>(v => v.VendorId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId);
        }
    }
}
