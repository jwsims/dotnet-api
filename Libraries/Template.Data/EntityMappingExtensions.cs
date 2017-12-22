using System;
using Microsoft.EntityFrameworkCore;

namespace Template.Data
{
    internal static class EntityMappingExtensions
    {
        public static ModelBuilder RegisterEntityMapping<TEntity, TMapping>(this ModelBuilder builder)
            where TMapping : EntityMappingConfiguration<TEntity>
            where TEntity : class
        {
            var mapper =
                (EntityMappingConfiguration<TEntity>) Activator.CreateInstance(typeof(TMapping));
            mapper.Map(builder.Entity<TEntity>());
            return builder;
        }

        public static ModelBuilder RegisterEntityMapping<TEntity>(this ModelBuilder builder)
            where TEntity : EntityMappingConfiguration<TEntity>
        {
            var mapper =
                (EntityMappingConfiguration<TEntity>) Activator.CreateInstance(typeof(TEntity));
            mapper.Map(builder.Entity<TEntity>());
            return builder;
        }
    }
}