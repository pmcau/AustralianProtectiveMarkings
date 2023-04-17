[TestFixture]
public class ParserTests
{
    [Test]
    public Task Simple()
    {
        var list = new List<string>
        {
            "VER=2018.4",
            "VER=2018.4, NS=gov.au",
            "VER=2018.4, NS=gov.au, SEC=TOP-SECRET",
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
            "SEC=SECRET, EXPIRES=2020-10-01, DOWNTO=TOP-SECRET"
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

        return Verify(dictionary).DontScrubDateTimes();
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
                var pair = Parser.ParseKeyValues(item).ToList();
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
}