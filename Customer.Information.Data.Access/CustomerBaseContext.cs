
using Customer.Information.Data.Access.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Customer.Information.Data.Access
{
    public abstract class CustomerBaseContext : DbContext
    {
        protected CustomerBaseContext(DbContextOptions options) : base(options)
        {
        }


        public virtual DbSet<tb_CustomerInformation> tb_CustomerInformation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.IncludeIgnoredWarning)
            //                                         .Ignore(CoreEventId.FirstWithoutOrderByAndFilterWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_CustomerInformation>(entity =>
            {
                entity.HasKey(e => e.CustomerRef);
                entity.ToTable("tb_CustomerInformation", "dbo");
                entity.Property(e => e.IdentificationNumber).HasDefaultValueSql("((1))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.FirstName).HasMaxLength(250);
                entity.Property(e => e.LastName).HasMaxLength(250);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            });


        }

        }
    }
