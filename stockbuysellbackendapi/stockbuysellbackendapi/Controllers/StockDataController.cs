using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Alpaca.Markets;
using Serilog;
using Environments = Alpaca.Markets.Environments;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    /*This is the master controller route aka the source to acess this controller if a client types in api/Myass they will get the stockdatacontorller and then we can select what method action we want*/
    [Route("api/[controller]")]
    public class StockDataController : ControllerBase
    {
        private static HttpClient _httpClient;
        public StockDataController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("ticker/{symbol}")]
        public async Task<string> Example(string symbol)
        {
            string uri = $"https://api.agify.io?name={symbol}";
            /*Here are all the async methods*/
            var response = await _httpClient.GetAsync(uri);
            /*
            var response = await _httpClient.DeleteAsync(uri);
            var response = await _httpClient.PostAsync(uri);
            var response = await _httpClient.PutAsync(uri);
            */
            var result = response.Content.ReadAsStringAsync();
            var headers = response.Headers;
            Log.Information("The headers of this task object that was sent back from the server is :\t {@headers}", headers);
            Log.Information("The content contained within this task object is none other than!!! :\t {@result}", result);
            return await response.Content.ReadAsStringAsync();
        }


        /*so really the action here is just sending this data back to the client and they can recieve and parse it as they please*/
        public ActionResult<string> TestThis()
        {
            return "This is a test of the emergency broadcast system";
        }
    }
}