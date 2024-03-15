using Serilog;

namespace stockbuysellbackendapi.Extensions;

public static class ExtensionMethods
{

    /*attaches my version of uppercase to the string object*/
        public static string ColesToUppercase(this string str)
        {
            Log.Information("The cole version of to uppercase was used");
            return str.ToUpper();
        }

}