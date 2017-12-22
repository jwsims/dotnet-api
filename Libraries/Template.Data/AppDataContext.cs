using Microsoft.EntityFrameworkCore;
using Template.Data.Entities;
using Template.Data.Mappings;

namespace Template.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntityMapping<Product, ProductMapping>();
            modelBuilder.RegisterEntityMapping<WorkOrder, WorkOrderMapping>();
        }
    }
}