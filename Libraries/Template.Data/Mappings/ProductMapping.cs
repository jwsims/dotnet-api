﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Data.Entities;

namespace Template.Data.Mappings
{
    internal class ProductMapping : EntityMappingConfiguration<Product>
    {
        internal override void Map(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product", "Production");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Product_Name")
                .IsUnique();

            entity.HasIndex(e => e.ProductNumber)
                .HasName("AK_Product_ProductNumber")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Product_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.Class).HasColumnType("nchar(2)");

            entity.Property(e => e.Color).HasMaxLength(15);

            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

            entity.Property(e => e.FinishedGoodsFlag)
                .HasColumnType("Flag")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.ListPrice).HasColumnType("money");

            entity.Property(e => e.MakeFlag)
                .HasColumnType("Flag")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("Name")
                .HasMaxLength(4000);

            entity.Property(e => e.ProductLine).HasColumnType("nchar(2)");

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

            entity.Property(e => e.ProductNumber)
                .IsRequired()
                .HasMaxLength(25);

            entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SellEndDate).HasColumnType("datetime");

            entity.Property(e => e.SellStartDate).HasColumnType("datetime");

            entity.Property(e => e.Size).HasMaxLength(5);

            entity.Property(e => e.SizeUnitMeasureCode).HasColumnType("nchar(3)");

            entity.Property(e => e.StandardCost).HasColumnType("money");

            entity.Property(e => e.Style).HasColumnType("nchar(2)");

            entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

            entity.Property(e => e.WeightUnitMeasureCode).HasColumnType("nchar(3)");
        }
    }
}