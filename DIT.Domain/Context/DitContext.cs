using Microsoft.EntityFrameworkCore;

namespace DIT.Domain.Context
{
    public sealed class DitContext : DbContext
    {
        private static readonly string defaultSchema = "dit";

        public DitContext(DbContextOptions<DitContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(defaultSchema);

            base.OnModelCreating(builder);
        }
    }
}
