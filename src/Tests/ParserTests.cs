[TestFixture]
public class ParserTests
{
    [Test]
    public Task Simple()
    {
        var list = new List<string>
        {
            "VER=2024.1",
            "VER=2024.1, NS=gov.au",
            "VER=2024.1, NS=gov.au, SEC=TOP-SECRET",
            "SEC=TOP-SECRET",
            "SEC= TOP-SECRET",
            "SEC=OFFICIAL:Sensitive",
            "SEC=unknown",
            "SEC=TOP-SECRET, CAVEAT=C:codeword1",
            "SEC=TOP-SECRET, CAVEAT=C:code word",
            "SEC=TOP-SECRET,CAVEAT=C:codeword1",
            "SEC=TOP-SECRET, CAVEAT=FG:usa caveat",
            "SEC=TOP-SECRET, CAVEAT=RI:AGAO",
            "SEC=TOP-SECRET, CAVEAT=RI:AGAO, CAVEAT=RI:AGAO",
            "SEC=TOP-SECRET, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET",
            "SEC=TOP-SECRET, CAVEAT=C:codeword1, CAVEAT=C:codeword2",
            "SEC=TOP-SECRET, CAVEAT=C:codeword1, CAVEAT=C:codeword1",
            "SEC=TOP-SECRET, CAVEAT=SH:EXCLUSIVE-FOR person",
            "SEC=TOP-SECRET, CAVEAT=SH:EXCLUSIVE-FOR person1, CAVEAT=SH:EXCLUSIVE-FOR person2",
            "SEC=TOP-SECRET, CAVEAT=REL:AGO",
            "SEC=TOP-SECRET, CAVEAT=REL:AGO/AIA",
            "SEC=TOP-SECRET, CAVEAT=REL:AGO/AGO",
            "SEC=TOP-SECRET, CAVEAT=REL:AGO, CAVEAT=REL:AGO",
            "SEC=TOP-SECRET, CAVEAT=REL:AGO, CAVEAT=REL:AIA",
            "SEC=TOP-SECRET, ACCESS=Legal-Privilege",
            "SEC=TOP-SECRET, ACCESS=unknown",
            "SEC=TOP-SECRET, ACCESS=Legal-Privilege, ACCESS=Legal-Privilege",
            "SEC=TOP-SECRET, ACCESS=Legal-Privilege, ACCESS=Legislative-Secrecy",
            "SEC=TOP-SECRET, ORIGIN=a@b.com",
            "SEC=TOP-SECRET, ORIGIN=a@b.com, ORIGIN=a@b.com",
            "SEC=TOP-SECRET, ORIGIN=a@b.com, ORIGIN=c@b.com",
            "SEC=TOP-SECRET, NOTE=the comment",
            "SEC=TOP-SECRET, NOTE=the comment, NOTE=the comment",
            "SEC=TOP-SECRET, NOTE=the comment, NOTE=other comment",
            "SEC=TOP-SECRET, EXPIRES=expiry",
            "SEC=TOP-SECRET, Unknown=expiry",
            "SEC=TOP-SECRET, EXPIRES=expiry1, EXPIRES=expiry2",
            "SEC=TOP-SECRET, EXPIRES=expiry1, EXPIRES=expiry1",
            "SEC=TOP-SECRET, EXPIRES=expiry1, EXPIRES=expiry1, DOWNTO=SECRET",
            "SEC=TOP-SECRET, DOWNTO=SECRET",
            "SEC=TOP-SECRET, DOWNTO=SECRET, DOWNTO=SECRET",
            "SEC=TOP-SECRET, EXPIRES=expiry, DOWNTO=SECRET, DOWNTO=UNOFFICIAL",
            "SEC=TOP-SECRET, EXPIRES=expiry, DOWNTO=SECRET",
            "SEC=TOP-SECRET, EXPIRES=2020-10-01, DOWNTO=SECRET",
            "SEC=TOP-SECRET, EXPIRES=2020-10-01, DOWNTO=TOP-SECRET",
            "SEC=SECRET, EXPIRES=2020-10-01, DOWNTO=TOP-SECRET",
            "Unofficial",
            "Official",
            "OfficialSensitive",
            "Protected",
            "Secret",
            "TopSecret",
            "UNOFFICIAL",
            "OFFICIAL",
            "OFFICIALSENSITIVE",
            "PROTECTED",
            "SECRET",
            "TOPSECRET"
        };

        var dictionary = new Dictionary<string, object>();
        foreach (var item in list)
        {
            try
            {
                var protectiveMarking = Parser.ParseProtectiveMarking(item);
                dictionary.Add(item, protectiveMarking);
            }
            catch (Exception exception)
            {
                dictionary.Add(item, exception);
            }
        }

        return Verify(dictionary)
            .DontScrubDateTimes();
    }

    [Test]
    public Task ParseKeyValues()
    {
        var list = new List<string>
        {
            "VER=Value",
            " VER=Value ",
            @"VER=The\=Value",
            @"VER=The\:Value",
            @"VER=The\,Value",
            @"VER=The\\Value",
            "VER=Value ",
            "VER= Value",
            """
            VER=Value,
            NS=Value
            """,
            "VER=Value,  NS=Value",
            "VER=Value,	NS=Value",
            "VER=Value, NS=Value2",
            "VER=Value, NS=Value"
        };

        var dictionary = new List<object>();
        foreach (var item in list)
        {
            try
            {
                var pair = Parser
                    .ParseKeyValues(item)
                    .ToList();
                dictionary.Add(new
                {
                    item,
                    pair
                });
            }
            catch (Exception exception)
            {
                dictionary.Add(new
                {
                    item,
                    exception
                });
            }
        }

        return Verify(dictionary);
    }

    [Test]
    public Task TryParseClassification()
    {
        var inputs = new List<string?>
        {
            // valid bare names (case-insensitive, whitespace-trimmed)
            "Unofficial", "Official", "OfficialSensitive", "Protected", "Secret", "TopSecret",
            "UNOFFICIAL", "official", " Protected ",
            // previously accepted by the lenient Enum.TryParse fast-path, now rejected
            "0", "3", "5",
            "Official, Secret", "Official, Protected",
            "OFFICIAL:Sensitive", "TOP-SECRET",
            "Unknown", "", " ", null
        };

        var results = new Dictionary<string, object>();
        foreach (var input in inputs)
        {
            var success = Parser.TryParseClassification(input!, out var classification);
            results.Add(
                input ?? "<null>",
                new
                {
                    success,
                    classification = success ? classification : (Classification?)null
                });
        }

        return Verify(results);
    }

    [Test]
    public void TryParseClassification_SpanOverload_MatchesStringOverload()
    {
        foreach (var input in new[] { "Protected", "official", " Secret ", "0", "Official, Secret", "Unknown", "" })
        {
            var stringResult = Parser.TryParseClassification(input, out var fromString);
            var spanResult = Parser.TryParseClassification(input.AsSpan(), out var fromSpan);
            Assert.That(spanResult, Is.EqualTo(stringResult), input);
            Assert.That(fromSpan, Is.EqualTo(fromString), input);
        }
    }

    [Test]
    public void ParseProtectiveMarking_SpanOverload_MatchesStringOverload()
    {
        // bare-classification fast path
        Assert.That(
            Parser.ParseProtectiveMarking("Protected".AsSpan()),
            Is.EqualTo(Parser.ParseProtectiveMarking("Protected")));
        // key-value path
        Assert.That(
            Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive".AsSpan()),
            Is.EqualTo(Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive")));
        // rejection still throws through the span overload
        Assert.Throws<Exception>(() => Parser.ParseProtectiveMarking("0".AsSpan()));
    }

    [Test]
    public void ParseProtectiveMarking_RejectsLenientClassificationInputs()
    {
        // Numeric and comma/flag inputs previously parsed (incorrectly) via Enum.TryParse and silently
        // produced a marking (e.g. "0" -> Unofficial, "Official, Secret" -> TopSecret). They must now be rejected.
        foreach (var input in new[] { "0", "3", "5", "Official, Secret", "Official, Protected" })
        {
            Assert.Throws<Exception>(
                () => Parser.ParseProtectiveMarking(input),
                $"Expected '{input}' to be rejected");
        }

        // Legitimate bare names still parse to the correct classification.
        Assert.That(Parser.ParseProtectiveMarking("Protected").Classification, Is.EqualTo(Classification.Protected));
        Assert.That(Parser.ParseProtectiveMarking("TopSecret").Classification, Is.EqualTo(Classification.TopSecret));
    }
}