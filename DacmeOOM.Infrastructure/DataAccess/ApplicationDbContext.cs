using DacmeOOM.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Entities
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeRoleModel> EmployeeRoles { get; set; }
        public DbSet<OrgLevelModel> OrgLevels { get; set; }
        public DbSet<OrgTypeModel> OrgTypes { get; set; }
        public DbSet<OrgUnitModel> OrgUnits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set Property types

            // EmployeeModel
            modelBuilder.Entity<EmployeeModel>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<EmployeeModel>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(x => x.Role)
                .WithOne(x => x.Employee)
                .HasForeignKey<EmployeeModel>(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // EmployeeRoleModel
            modelBuilder.Entity<EmployeeRoleModel>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<EmployeeRoleModel>()
                .Property(x => x.Path)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<EmployeeRoleModel>()
                .HasOne(x => x.Employee)
                .WithOne(x => x.Role)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeRoleModel>()
                .HasOne(x => x.OrgUnit)
                .WithMany(x => x.Roles)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeRoleModel>()
                .HasOne(x => x.Org)
                .WithMany(x => x.EmployeeRoles)
                .OnDelete(DeleteBehavior.NoAction);


            // OrgLevelModel
            modelBuilder.Entity<OrgLevelModel>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            // OrgTypeModel
            modelBuilder.Entity<OrgTypeModel>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            // OrgUnitModel
            modelBuilder.Entity<OrgUnitModel>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<OrgUnitModel>()
                .Property(x => x.Path)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<OrgUnitModel>()
                .HasOne(x => x.Org)
                .WithMany(x => x.OrgUnits)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                         CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                SetTimeStamps(entry, utcNow);
            }
        }

        private static void SetTimeStamps(EntityEntry entry, DateTime utcNow)
        {
            // for entities that inherit from BaseEntity,
            // set UpdatedOn / CreatedOn appropriately
            if (entry.Entity is BaseModel trackable)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // set the updated date to "now"
                        trackable.Updated = utcNow;

                        // mark property as "don't touch"
                        // we don't want to update on a Modify operation
                        entry.Property("Created").IsModified = false;
                        break;

                    case EntityState.Added:
                        // set both updated and created date to "now"
                        trackable.Created = utcNow;
                        trackable.Updated = utcNow;
                        break;
                }
            }
        }


    }
}
