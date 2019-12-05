using DIT.Domain.Models;
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

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Connector> Connectors { get; set; }
        public DbSet<ProjectConnector> ProjectConnectors { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessContent> ProcessContents { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<FlowContent> FlowContents { get; set; }

    }
}