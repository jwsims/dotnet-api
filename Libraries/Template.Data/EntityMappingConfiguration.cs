using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Data
{
    public abstract class EntityMappingConfiguration<T> where T : class
    {
        internal abstract void Map(EntityTypeBuilder<T> entity);
    }
}