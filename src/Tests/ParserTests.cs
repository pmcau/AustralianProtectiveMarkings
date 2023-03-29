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
        };

        var dictionary = new Dictionary<string, object>();
        foreach (var item in list)
        {
            try
            {
                var protectiveMarking = Parser.Parse(item);
                dictionary.Add(item, protectiveMarking);
            }
            catch (Exception exception)
            {
                dictionary.Add(item, exception);
            }
        }

        return Verify(dictionary);
    }
}