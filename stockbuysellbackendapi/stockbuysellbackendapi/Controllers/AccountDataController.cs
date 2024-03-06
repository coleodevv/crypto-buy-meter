using Microsoft.AspNetCore.Mvc;
using Serilog;
using Alpaca.Markets;
using stockbuysellbackendapi.Passwords;
using Environments = Alpaca.Markets.Environments;

namespace stockbuysellbackendapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountDataController : ControllerBase
{
    [HttpGet]
    [Route("profile/{password}")]
    public async Task<string> GetProfile(string password)
    {
        KeyVault keyVault = new KeyVault(password);
        string keyId = keyVault.GetKeyId();
        string secretKey = keyVault.GetSecretKey();

        Log.Information("Here are your key values:\n KeyId: {id} \n SecretKey: {secretkey} ", keyId, secretKey);

        var tradingClient = Environments.Paper.GetAlpacaTradingClient(new SecretKey(keyId, secretKey));
        var account = await tradingClient.GetAccountAsync();


        return "The total current buying power in your account is:\t" + account.BuyingPower;
    }
}