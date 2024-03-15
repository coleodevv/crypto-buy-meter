using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stockbuysellbackendapi.Models;
using System;
using Alpaca.Markets;
using System.Threading.Tasks;
using Serilog;
using Environments = Alpaca.Markets.Environments;


namespace stockbuysellbackendapi.Controllers;

public class HomeController : Controller
{

    public ActionResult<string> HomePage()
    {
        return "Welcome to the homepage";
    }

    public async Task AlpacaClock()
    {
    }
}