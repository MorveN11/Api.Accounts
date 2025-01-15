using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain;

namespace Infrastructure.Database.Configurations.Abstractions;

public abstract class BaseEntityMap<TEntity> : BaseRegisterMap<TEntity>
    where TEntity : Entity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        _ = builder.HasKey(e => e.Id);

        base.Configure(builder);
    }
}
