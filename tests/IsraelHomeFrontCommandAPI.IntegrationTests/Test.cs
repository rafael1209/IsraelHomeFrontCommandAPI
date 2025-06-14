using IsraelHomeFrontCommandAPI.Enums;
using Xunit;

namespace IsraelHomeFrontCommandAPI.IntegrationTests;

public class Test
{
    [Fact]
    public async Task TestCurrentAlert()
    {
        HomeFrontCommandClient client = new HomeFrontCommandClient();

        var response = await client.GetActiveAlertsAsync();

        Assert.True(response != null);
    }

    [Fact]
    public async Task TestAlertsHistory()
    {
        HomeFrontCommandClient client = new HomeFrontCommandClient(Language.Russian);

        var response = await client.GetAlertsHistoryLastDayAsync();

        Assert.True(response != null);
    }
}