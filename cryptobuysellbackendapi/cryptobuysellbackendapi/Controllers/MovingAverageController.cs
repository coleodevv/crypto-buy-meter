using Microsoft.AspNetCore.Mvc;
using Serilog;
using stockbuysellbackendapi.Passwords;

namespace stockbuysellbackendapi.Controllers;

[ApiController]
[Route("api")]
public class MovingAverageController : ControllerBase
{

    [HttpGet]
    [Route("deprecated/{ticker}")]
    public async Task<string> Deprecated(string ticker)
    {
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
        tickerList.RemoveAt(listLength - 1);
        string[] tickerArray = tickerList.ToArray();
        string combined = string.Join("", tickerArray);
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


    [HttpGet]
    [Route("sma/{symbol}")]
    public async Task<string> GetSimpleMovingAverage(string symbol)
    {
        var vault = new KeyVault("kittycat123");
        string keyId = vault.GetPolygonKeyId();
        HttpClient httpClient = new HttpClient();
        /*let the client know that the format for entering a symbol is  SYMBOLUSD  they must tack usd on the end*/
        string symbolToUpper = symbol.ToUpper();
        Log.Information($"The value of to upper is : {symbolToUpper}");
        string uri = $"https://api.polygon.io/v1/indicators/sma/X:{symbolToUpper}USD?timestamp=2024-03-15&timespan=day&window=100&series_type=close&order=asc&apiKey={keyId}";
        var result = await httpClient.GetAsync(uri);
        string content = await result.Content.ReadAsStringAsync();

        return content;

    }
}