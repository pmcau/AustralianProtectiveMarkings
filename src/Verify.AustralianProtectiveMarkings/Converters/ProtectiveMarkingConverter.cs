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
        writer.WriteMember(value, value.Caveats, "Caveats");
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
}