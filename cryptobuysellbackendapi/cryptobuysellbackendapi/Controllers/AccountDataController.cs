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
        if (keyId == null | secretKey == null)
        {
            return "One or both of your keys returned null";
        }

        var tradingClient = Environments.Paper.GetAlpacaTradingClient(new SecretKey(keyId, secretKey));
        var account = await tradingClient.GetAccountAsync();

        return "The entire printout of your account:\t" + account;
    }
}
