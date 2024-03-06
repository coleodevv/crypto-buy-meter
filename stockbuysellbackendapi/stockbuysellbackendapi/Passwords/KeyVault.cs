namespace stockbuysellbackendapi.Passwords;

public class KeyVault
{
    private readonly string _keyId = "PKXPZPQW6UMFM8IEHR4H";
    private readonly string _secretKey = "xXeHB4BfZkH5TvruJKPxTnuVR5YbI7m0tUINy3BN";
    private string _secretPassword { get; set; }
    private string _secretPasswordAnswer = "crazyhardpassword";

    public KeyVault(string secretPassword)
    {
        _secretPassword = secretPassword;
    }

    public string GetKeyId()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return this._keyId;
        }
        else
        {
            return "Acess denied that is not the correct password";
        }
    }

    public string GetSecretKey()
    {
        if (_secretPassword == _secretPasswordAnswer)
        {
            return this._secretKey;
        }
        else
        {
            return "Acess denied that is not the correct password";
        }
    }
}