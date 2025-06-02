namespace PersistenceLayer.DataAccess.Mapping.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Mapping for <see cref="SubscriptionEntity"/>.
/// </summary>
public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<SubscriptionEntity> builder)
    {
        builder.ToTable("Subscriptions", "Identity");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Type).IsRequired().HasMaxLength(50);
        builder.Property(s => s.PlanName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.IsActive).HasDefaultValue(true);
        builder.Property(s => s.AutoRenew).HasDefaultValue(true);
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_SubscriptionEntity_UserId_UserEntity_Id")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => p.UserId)
            .HasDatabaseName("IX_SubscriptionEntity_UserId_UserEntity_Id");
    }
}