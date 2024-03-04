using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Serilog;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    /*This is the master controller route aka the source to acess this controller if a client types in api/Myass they will get the stockdatacontorller and then we can select what method action we want*/
    [Route("api")]
    public class StockDataController : ControllerBase
    {
        private static HttpClient _httpClient;

        public StockDataController()
        {
/*its really that simple dp inject is really just getting an external context and injecting it on instantantion*/
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("stockdata/{ticker}")]
 public async Task<string> GetTicker(string ticker)
        {
            string uri = $"https://api.agify.io?name={ticker}";
            /*Here are all the async methods*/
            var response = await _httpClient.GetAsync(uri);
            /*
            var response = await _httpClient.DeleteAsync();
            var response = await _httpClient.PostAsync();
            var response = await _httpClient.PutAsync();
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