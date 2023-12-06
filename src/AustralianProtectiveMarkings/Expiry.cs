namespace AustralianProtectiveMarkings;

/// <summary>
/// Represents how/when a classification will be downgraded.
/// </summary>
public record struct Expiry
{
    readonly string? @event;
    readonly DateTimeOffset? genDate;

    /// <summary>
    /// The classification that will be downgraded to when <see cref="Event" /> or <see cref="GenDate" /> occurs.
    /// </summary>
    public required Classification DownTo { get; init; }

    /// <summary>
    /// The date that will trigger the classification expiry.
    /// Maps to: the EXPIRES=genDate
    /// </summary>
    /// <exception cref="Exception"></exception>
    public DateTimeOffset? GenDate
    {
        readonly get => genDate;
        init
        {
            if (value == null)
            {
                return;
            }

            if (Event != null)
            {
                throw new("Cannot define GenDate when Event has a value");
            }

            genDate = value;
        }
    }

    /// <summary>
    /// The event that will trigger the classification expiry.
    /// Maps to: the EXPIRES=genDate
    /// </summary>
    public string? Event
    {
        readonly get => @event;
        init
        {
            if (value == null)
            {
                return;
            }

            if (GenDate != null)
            {
                throw new("Cannot define Event when GenDate has a value");
            }

            TextValidator.Validate(value);

            @event = value;
        }
    }
}