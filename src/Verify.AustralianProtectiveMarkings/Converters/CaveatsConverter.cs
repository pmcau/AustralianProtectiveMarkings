class CaveatsConverter :
    WriteOnlyJsonConverter<Caveats>
{
    public override void Write(VerifyJsonWriter writer, Caveats value)
    {
        if (value.Codeword == null &&
            value.ForeignGovernment == null &&
            value.ExclusiveFor == null &&
            value.CountryCodes == null)
        {
            var list = new List<string>();
            if (value.Agao)
            {
                list.Add("Agao");
            }

            if (value.Austeo)
            {
                list.Add("Austeo");
            }

            if (value.DelicateSource)
            {
                list.Add("DelicateSource");
            }

            if (value.Orcon)
            {
                list.Add("Orcon");
            }

            if (value.Cabinet)
            {
                list.Add("Cabinet");
            }

            if (value.NationalCabinet)
            {
                list.Add("NationalCabinet");
            }

            writer.WriteValue(string.Join(", ",list));

            return;
        }

        writer.WriteStartObject();
        writer.WriteMember(value, value.Codeword, "Codeword");
        writer.WriteMember(value, value.ForeignGovernment, "ForeignGovernment");
        writer.WriteMember(value, value.ExclusiveFor, "ExclusiveFor");
        writer.WriteMember(value, value.CountryCodes, "CountryCodes");

        if (value.Agao)
        {
            writer.WriteMember(value, value.Agao, "Agao");
        }

        if (value.Austeo)
        {
            writer.WriteMember(value, value.Austeo, "Austeo");
        }

        if (value.DelicateSource)
        {
            writer.WriteMember(value, value.DelicateSource, "DelicateSource");
        }

        if (value.Orcon)
        {
            writer.WriteMember(value, value.Orcon, "Orcon");
        }

        if (value.Cabinet)
        {
            writer.WriteMember(value, value.Cabinet, "Cabinet");
        }

        if (value.NationalCabinet)
        {
            writer.WriteMember(value, value.NationalCabinet, "NationalCabinet");
        }

        writer.WriteEndObject();
    }
}