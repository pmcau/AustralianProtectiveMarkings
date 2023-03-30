namespace AustralianProtectiveMarkings;

public record struct Expiry
{
    readonly string? @event;
    readonly DateTimeOffset? genDate;
    public required Classification DownTo { get; init; }

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