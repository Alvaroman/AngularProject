using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ceiba.ParkingLotADN.Application.ParkingLot.Queries;
using Xunit;

namespace Ceiba.ParkingLotADN.Api.Tests
{
    public class ParkingLotControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public ParkingLotControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task PostParkingLotFailureAsync()
        {
            var postContent = new Ceiba.ParkingLotADN.Application.ParkingLot.Commands.ParkingLotCreateCommand
            (
               3, "abc-999", new System.DateTime(year: 2022, month: 03, day: 20), 2000
            );
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postContent), System.Text.Encoding.UTF8, "text/json");
            var c = await _client.PostAsync("api/Parking", content);
            Assert.Throws<System.Net.Http.HttpRequestException>(() => c.EnsureSuccessStatusCode());
        }

        [Fact]
        public async Task GetParkingLotFailureAsync()
        {
            var c = await _client.GetAsync($"api/Parking/{Guid.NewGuid()}");
            c.EnsureSuccessStatusCode();
            var response = await c.Content.ReadAsStringAsync();
            Assert.Throws<System.Text.Json.JsonException>(() =>
                System.Text.Json.JsonSerializer.Deserialize<ParkingLotDto>(response));
        }

        [Fact]
        public async Task GetParkingLotBadRequestFailureAsync()
        {
            var c = await _client.GetAsync($"api/Parking/foobar");
            Assert.Throws<System.Net.Http.HttpRequestException>(() => c.EnsureSuccessStatusCode());
        }

        [Fact]
        public async Task GetParkingLotsSuccessAsync()
        {
            var c = await _client.GetAsync($"api/Parking");
            c.EnsureSuccessStatusCode();
            Assert.True(c.IsSuccessStatusCode);
        }
        [Fact]
        public async Task GetParkingLotCostFailureAsync()
        {
            var c = await _client.GetAsync($"api/Parking/{Guid.NewGuid()}/cost");
            Assert.Throws<System.Net.Http.HttpRequestException>(() => c.EnsureSuccessStatusCode());
        }
        [Fact]
        public async Task ReleaseParkingLotFailureAsync()
        {
            var c = await _client.GetAsync($"api/Parking/{Guid.NewGuid()}/release");
            Assert.Throws<System.Net.Http.HttpRequestException>(() => c.EnsureSuccessStatusCode());
        }
    }
}
