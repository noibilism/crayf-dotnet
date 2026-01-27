using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cray.Exceptions;
using Moq;
using Moq.Protected;
using Xunit;

namespace Cray.Tests
{
    public class CrayClientTests
    {
        [Fact]
        public void Constructor_ShouldInitializeServices()
        {
            var client = new CrayClient("https://api.cray.com", "token");

            Assert.NotNull(client.Cards);
            Assert.NotNull(client.MoMo);
            Assert.NotNull(client.Wallets);
            Assert.NotNull(client.FX);
            Assert.NotNull(client.Payouts);
            Assert.NotNull(client.Refunds);
        }

        // Note: To test HTTP calls properly, we would need to inject HttpMessageHandler into CrayClient.
        // For now, we are testing the structure.
    }
}
