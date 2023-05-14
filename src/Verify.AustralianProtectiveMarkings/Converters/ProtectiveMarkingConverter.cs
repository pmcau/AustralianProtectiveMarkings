using AustralianProtectiveMarkings;

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
        if (value.Caveats != null)
        {
            writer.WriteMember(value, value.Caveats, "Caveats");
        }

        if (value.Expiry != null)
        {
            writer.WriteMember(value, value.Expiry, "Expiry");
        }

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

        if (value.Comment != null)
        {
            writer.WriteMember(value, value.Comment, "Comment");
        }

        if (value.AuthorEmail != null)
        {
            writer.WriteMember(value, value.AuthorEmail, "AuthorEmail");
        }

        writer.WriteEndObject();
    }
}