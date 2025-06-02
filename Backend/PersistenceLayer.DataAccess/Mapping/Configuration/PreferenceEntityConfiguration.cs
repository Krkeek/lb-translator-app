namespace PersistenceLayer.DataAccess.Mapping.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Configuration;

/// <summary>
/// Mapping for <see cref="PreferenceEntity"/>.
/// </summary>
public class PreferenceEntityConfiguration : IEntityTypeConfiguration<PreferenceEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<PreferenceEntity> builder)
    {
        builder.ToTable("Preferences", "Configuration");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Type).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Value).IsRequired().HasMaxLength(50);
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        builder
            .HasOne(p => p.User)
            .WithMany(u => u.Preferences)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_PreferenceEntity_UserId_UserEntity_Id")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => p.UserId)
            .HasDatabaseName("IX_PreferenceEntity_UserId_UserEntity_Id");
    }
}