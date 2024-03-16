using Serilog;

namespace stockbuysellbackendapi.Passwords;

public class KeyVault
{
    /*key ids are what tell the server who you are*/
    private readonly string _keyId = "PKNOC5ZJAKBF2D9WTCED";
    /*secrete keys are the acatual password once the server knows who you are*/
    private readonly string _secretKey = "g1rOz49BfGp7uYgk56cbZrQ30HPfwHwYYJblfV9A";
    private readonly string _smaApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjbHVlIjoiNjVmNDRkNGUyYzczYzFlM2ZkMTg5ZTYzIiwiaWF0IjoxNzEwNTA5NDIyLCJleHAiOjMzMjE0OTczNDIyfQ.uhf4UfzAdInIdyz8ftSqZkqcth0ZonPS3L4iSXaUIBE";
    private readonly string _polygonKeyId = "5_RcdE_Q4h1kIkrv8Q76ov8XIUh_Ea8a";

    private string _secretPassword { get; }
    private string _secretPasswordAnswer = "kittycat123";

    public KeyVault(string secretPassword)
    {
        _secretPassword = secretPassword;
    }

    public string? GetKeyId()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return _keyId;
        }
        else
        {
            return null;
        }
    }


    public string? GetPolygonKeyId()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return _polygonKeyId;
        }
        else
        {
            return null;
        }
    }


    public string? GetSecretKey()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return _secretKey;
        }
        else
        {
            return null;
        }
    }


    public string? GetSmaId()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return _smaApiKey;
        }
        else
        {
            return null;
        }
    }
}