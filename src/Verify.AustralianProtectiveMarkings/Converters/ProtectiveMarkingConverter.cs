class ProtectiveMarkingConverter :
    WriteOnlyJsonConverter<ProtectiveMarking>
{
    public override void Write(VerifyJsonWriter writer, ProtectiveMarking value)
    {
        var classification = value.Classification.ToString();
        if (value is
            {
                LegalPrivilege: false,
                LegislativeSecrecy: false,
                PersonalPrivacy: false,
                Caveats: null,
                Comment: null,
                Expiry: null,
                AuthorEmail: null
            })
        {
            writer.WriteValue(classification);
            return;
        }

        writer.WriteStartObject();
        writer.WriteMember(value, classification, "Classification");
        var caveats = value.Caveats;
        if (caveats.HasValue)
        {
            WriteCaveats(writer, value, caveats.Value);
        }

        writer.WriteMember(value, value.Expiry, "Expiry");
        if (value.PersonalPrivacy)
        {
            writer.WriteMember(value, true, "PersonalPrivacy");
        }

        if (value.LegalPrivilege)
        {
            writer.WriteMember(value, true, "LegalPrivilege");
        }

        if (value.LegislativeSecrecy)
        {
            writer.WriteMember(value, true, "LegislativeSecrecy");
        }

        writer.WriteMember(value, value.Comment, "Comment");
        writer.WriteMember(value, value.AuthorEmail, "AuthorEmail");

        writer.WriteEndObject();
    }

    static void WriteCaveats(VerifyJsonWriter writer, ProtectiveMarking value, Caveats caveats)
    {
        if (caveats is
            {
                Agao: false,
                Austeo: false,
                Cabinet: false,
                Orcon: false,
                DelicateSource: false,
                NationalCabinet: false,
                Codeword: null,
                CountryCodes: null,
                ExclusiveFor: null,
                ForeignGovernment: null
            })
        {
            return;
        }

        writer.WriteMember(value, caveats, "Caveats");
    }
}