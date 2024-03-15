using Microsoft.AspNetCore.Mvc;
using Serilog;
using stockbuysellbackendapi.Passwords;

namespace stockbuysellbackendapi.Controllers;


[ApiController]
[Route("api")]
public class MovingAverageController
{

    [Route("sma/{ticker}")]
    public async Task<string> GetSimpleMovingAverage(string ticker){
        KeyVault vault = new KeyVault("kittycat123");
        string id = vault.GetSmaId();
        HttpClient httpClient = new HttpClient();

        /*solution if the second /symbol is other than usdt*/
       string[] splitword = ticker.Split(",");
       List<string> tickerList = new List<string>();
       foreach (var word in splitword)
       {
           Log.Information($"The current word is {word}");
           tickerList.Add(word);
           tickerList.Add("/");
       }
       int listLength = tickerList.Count;
       tickerList.RemoveAt(listLength-1);
       string[] tickerArray = tickerList.ToArray();
       string combined = string.Join("",tickerArray);
       string tickerToUpper = combined.ToUpper();

       /*better solution*/
       string combo = ticker + "/USDT";
       string toUpperTicker = combo.ToUpper();

       Log.Information($"Here is the ticker to upper: {toUpperTicker}");
       /*add to list and then chop off the last chop off the last item in the list*/


       /*If the symbol is above the 1day EMA in price then you buy*/
        string uri = $"https://api.taapi.io/sma?secret={id}&exchange=binance&symbol={toUpperTicker}&interval=1d";
        var result = await httpClient.GetAsync(uri);
        string content = await result.Content.ReadAsStringAsync();


        return content;
    }
    
}