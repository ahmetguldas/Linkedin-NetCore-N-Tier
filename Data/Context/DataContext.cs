using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<LicenseOfCertification> LicenseOfCertifications { get; set; }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ed => ed.UserId);

            modelBuilder.Entity<Experience>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ex => ex.UserId);

            modelBuilder.Entity<LicenseOfCertification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId);
        }
        //veritabani interceptor islemi
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //ChangeTracker:Entityler uzerinden yapilan degisikliklerin yada yeni eklenen verinin yakalanmasini saglayan propertydir.Update operasyonlarinda Track edilen verileri yakalayip elde etmemizi saglar.
        //var datas = ChangeTracker.Entries<BaseEntity>();
        //foreach (var data in datas)
        //{
        //    _ = data.State switch
        //    {
        //        EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
        //        EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
        //    };
        //}
        //return await base.SaveChangesAsync(cancellationToken);
    }
}
