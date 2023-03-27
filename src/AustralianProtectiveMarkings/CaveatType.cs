namespace AustralianProtectiveMarkings;

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information10 and requires a security classification of PROTECTED or higher (with the exception of
/// the NATIONAL CABINET caveat, which can appear in conjunction with either the OFFICIAL: Sensitive marking or a security classification).
/// </summary>
public enum CaveatType
{
    // C
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    Codeword,
    // FG
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    ForeignGovernment,
    // SH
    SpecialHandling,
    // RI
    ReleasabilityIndicator
}