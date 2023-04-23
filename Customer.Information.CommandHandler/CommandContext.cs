
using Customer.Information.Data.Access;
using CustomerInformation.Core.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Information.CommandHandler
{
    public class CommandContext : CustomerBaseContext
    {
      
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
            
        }

        public void OnBeforeSaving()
        {
            var auditables = ChangeTracker.Entries<IAuditable>();

            if (auditables != null)
            {
             

                foreach (var item in auditables.Where(t => t.State == EntityState.Added))
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.CreatedBy = 197887;
                    item.Entity.ModifiedDate = DateTime.Now;
                    item.Entity.ModifiedBy=197887;
                    item.Entity.IsDeleted = false;
                }
                foreach (var item in auditables.Where(t => t.State == EntityState.Modified))
                {
                    item.Entity.ModifiedDate = DateTime.Now;
                    
                }

                foreach (var item in auditables.Where(t => t.State == EntityState.Deleted))
                {
                    item.State = EntityState.Modified;
                    item.Entity.ModifiedDate = DateTime.Now;
                    
                    item.Entity.IsDeleted = true;
                }
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
    }
}