using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Alpaca.Markets;
using Serilog;
using Environments = Alpaca.Markets.Environments;
using RestSharp;
using stockbuysellbackendapi.Passwords;
using System;
using System.Web;
using stockbuysellbackendapi.Extensions;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    /*This is the master controller route aka the source to acess this controller if a client types in api/Myass they will get the stockdatacontorller and then we can select what method action we want*/
    [Route("api")]
    public class StockDataController : ControllerBase
    {
        private static HttpClient _httpClient;
        public string name { get; set; }
        public int age { get; set; }
        public double calculation  { get; set; }
        public string flavor { get; set; }

        public StockDataController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("ticker/{symbol}")]
        public async Task<string> Example(string symbol)
        {
            var vault = new KeyVault("kittycat1234");
            string keyId = vault.GetKeyId();
            string secretKey = vault.GetSecretKey();
            string amd = "AMD";
            string upperCase = symbol.ColesToUppercase();
            var options = new RestClientOptions($"https://paper-api.alpaca.markets/v2/assets/{upperCase}");
            /*
            var options = new RestClientOptions($"https://paper-api.alpaca.markets/v2/assets?status=active&asset_class=us_equity&exchange=NASDAQ&attributes=");
            */
            var restClient = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("APCA-API-KEY-ID", $"{keyId}");
            request.AddHeader("APCA-API-SECRET-KEY", $"{secretKey}");
            var response = await restClient.GetAsync(request);

            return response.Content;

            /*
            var options = new RestClientOptions("https://paper-api.alpaca.markets/v2/assets/BTCUSD");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("APCA-API-KEY-ID", "PKNOC5ZJAKBF2D9WTCED");
            request.AddHeader("APCA-API-SECRET-KEY", "g1rOz49BfGp7uYgk56cbZrQ30HPfwHwYYJblfV9A");
            var response = await client.GetAsync(request);
            */

            /*
            string uri = $"https://paper-api.alpaca.markets/v2/assets/{symbol}";
            /*GET request to api#1#
            var response = await _httpClient.GetAsync(uri);

            /*
            var response = await _httpClient.DeleteAsync(uri);
            var response = await _httpClient.PostAsync(uri);
            var response = await _httpClient.PutAsync(uri);
            #1#
            return await response.Content.ReadAsStringAsync();
            */
        }


        /*so really the action here is just sending this data back to the client and they can recieve and parse it as they please*/
        public ActionResult<string> TestThis()
        {
            return "This is a test of the emergency broadcast system";
        }
    }
}