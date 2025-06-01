namespace PersistenceLayer.DataAccess.Mapping.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Core;

/// <summary>
/// Mapping for <see cref="TopTranslationEntity"/>.
/// </summary>
public class TopTranslationEntityConfiguration : IEntityTypeConfiguration<TopTranslationEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<TopTranslationEntity> builder)
    {
        builder.ToTable("TopTranslations", "Core");

        builder.HasKey(tt => tt.Id);
        builder.Property(tt => tt.OriginalText).HasMaxLength(200);
        builder.Property(tt => tt.SourceLanguage).HasMaxLength(10);
        builder.Property(tt => tt.TargetLanguage).HasMaxLength(10);
        builder.HasOne(tt => tt.User)
            .WithMany(u => u.TopTranslations)
            .HasForeignKey(tt => tt.UserId)
            .HasConstraintName("FK_TopTranslations_UserId_Users_Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tt => tt.Translation)
            .WithOne(t => t.TopTranslation)
            .HasForeignKey<TopTranslationEntity>(tt => tt.TranslationId)
            .HasConstraintName("FK_TopTranslations_TranslationId_Translations_Id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(tt => tt.UserId).HasDatabaseName("IX_TopTranslations_UserId_Users_Id");
        builder.HasIndex(tt => tt.TranslationId).IsUnique().HasDatabaseName("IX_TopTranslations_TranslationId_Translations_Id");
    }
}