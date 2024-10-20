using Xunit;

namespace IsraelHomeFrontCommandAPI.IntegrationTests
{
    public class Test
    {
        [Fact]
        public async Task TestCurrentAlert()
        {
            HomeFrontCommandClient client = new HomeFrontCommandClient();

            var response = await client.GetActiveAlertsAsync();

            Assert.True(response != null);
        }
    }
}
