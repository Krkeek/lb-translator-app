using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Suppressed for DbContext file")]

namespace PersistenceLayer.DataAccess.Context;

using Microsoft.EntityFrameworkCore;
using PersistenceLayer.DataAccess.Entities.Configuration;
using PersistenceLayer.DataAccess.Entities.Core;
using PersistenceLayer.DataAccess.Entities.Identity;
using PersistenceLayer.DataAccess.Entities.Log;

/// <summary>
/// Represents the application's database context, providing access to entity sets and configuring entity mappings.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<UserEntity> Users => this.Set<UserEntity>();

    public DbSet<SubscriptionEntity> Subscriptions => this.Set<SubscriptionEntity>();

    public DbSet<PreferenceEntity> Preferences => this.Set<PreferenceEntity>();

    public DbSet<TranslationEntity> Translations => this.Set<TranslationEntity>();

    public DbSet<TopTranslationEntity> TopTranslations => this.Set<TopTranslationEntity>();

    public DbSet<LogEntryEntity> LogEntries => this.Set<LogEntryEntity>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
#pragma warning restore 1591
