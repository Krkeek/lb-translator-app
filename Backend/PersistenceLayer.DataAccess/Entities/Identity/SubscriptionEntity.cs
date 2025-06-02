namespace PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Represents a subscription record for a user.
/// </summary>
public class SubscriptionEntity
{
    /// <summary>
    /// Gets or sets the subscription ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the associated user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the type of the subscription.
    /// </summary>
    public string Type { get; set; } = default!;

    /// <summary>
    /// Gets or sets the start date of the subscription.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the subscription.
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the subscription plan.
    /// </summary>
    public string PlanName { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the subscription is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets a value indicating whether the subscription should auto-renew.
    /// </summary>
    public bool AutoRenew { get; init; }

    /// <summary>
    /// Gets the associated user entity.
    /// </summary>
    public UserEntity User { get; init; } = default!;
}