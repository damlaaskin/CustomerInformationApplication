
using Customer.Information.Data.Access;
using Microsoft.EntityFrameworkCore;

namespace HR.Harmony.Query.Handler
{
    public class QueryContext : CustomerBaseContext
    {
        

        public QueryContext(DbContextOptions<QueryContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new InvalidOperationException("This context is read-only.");
        //}

        //public override int SaveChanges()
        //{
        //    throw new InvalidOperationException("This context is read-only.");
        //}
    }
}