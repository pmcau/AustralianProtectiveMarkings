[TestFixture]
public class ParseTests
{
    [Test]
    public void GetAustralia()
    {
        var data2016 = DataLoader.Maps2016.GetAustralia();
        Assert.NotEmpty(data2016);
        Assert.NotNull(data2016);
        var data2019 = DataLoader.Maps2019.GetAustralia();
        Assert.NotEmpty(data2019);
        Assert.NotNull(data2019);
        var data2022 = DataLoader.Maps2022.GetAustralia();
        Assert.NotEmpty(data2022);
        Assert.NotNull(data2022);
        // var dataFuture = DataLoader.MapsFuture.GetAustralia();
        // Assert.NotEmpty(dataFuture);
        // Assert.NotNull(dataFuture);
    }
}