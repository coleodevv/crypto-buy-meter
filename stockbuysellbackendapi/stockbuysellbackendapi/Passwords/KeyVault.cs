namespace stockbuysellbackendapi.Passwords;

public class KeyVault
{
    /*key ids are what tell the server who you are*/
    private readonly string _keyId = "PKNOC5ZJAKBF2D9WTCED";
    /*secrete keys are the acatual password once the server knows who you are*/
    private readonly string _secretKey = "g1rOz49BfGp7uYgk56cbZrQ30HPfwHwYYJblfV9A";
    private string _secretPassword { get; }
    private string _secretPasswordAnswer = "kittycat1234";

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
}