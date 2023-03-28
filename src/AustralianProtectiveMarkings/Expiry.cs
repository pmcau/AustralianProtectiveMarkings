namespace AustralianProtectiveMarkings;

public record struct Expiry
{
    public required SecurityClassification DownTo { get; init; }
    public DateTimeOffset? GenDate { get; init; }
    public string? Event { get; init; }
}