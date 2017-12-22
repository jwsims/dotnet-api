using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Data.Entities;

namespace Template.Data.Mappings
{
    internal class WorkOrderMapping : EntityMappingConfiguration<WorkOrder>
    {
        internal override void Map(EntityTypeBuilder<WorkOrder> entity)
        {
            entity.ToTable("WorkOrder", "Production");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.ScrapReasonId);

            entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

            entity.Property(e => e.DueDate).HasColumnType("datetime");

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.ScrapReasonId).HasColumnName("ScrapReasonID");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.StockedQty).HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.WorkOrder)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}