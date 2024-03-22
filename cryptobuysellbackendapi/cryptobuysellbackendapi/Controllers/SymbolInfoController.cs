using Microsoft.AspNetCore.Mvc;
using Serilog;
using stockbuysellbackendapi.Passwords;

namespace stockbuysellbackendapi.Controllers;

[ApiController]
[Route("api")]
public class SymbolInfoController : ControllerBase
{
    [HttpGet]
    [Route("symbolinfo/{symbol}")]
    public async Task<string> GetSymbolInfo(string symbol)
    {
        var vault = new KeyVault("kittycat123");
        string keyId = vault.GetPolygonKeyId();
        HttpClient httpClient = new HttpClient();
        /*let the client know that the format for entering a symbol is  SYMBOLUSD  they must tack usd on the end*/
        string symbolToUpper = symbol.ToUpper();
        Log.Information($"The value of to upper is : {symbolToUpper}");
        string uri = $"https://api.polygon.io/v2/aggs/ticker/X:{symbolToUpper}USD/prev?adjusted=true&apiKey=5_RcdE_Q4h1kIkrv8Q76ov8XIUh_Ea8a";
        var result = await httpClient.GetAsync(uri);
        string content = await result.Content.ReadAsStringAsync();

        return content;

    }
}