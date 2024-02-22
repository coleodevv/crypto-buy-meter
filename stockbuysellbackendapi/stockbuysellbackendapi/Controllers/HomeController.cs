using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stockbuysellbackendapi.Models;


namespace stockbuysellbackendapi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /*we are using dp injection to get ourselves a logger*/
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [Route("Home/ReadCustomerId/{customerId}")]
    public string ReadCustomerId(int customerId)
    {
        return $"The cusomter has an id of {customerId}";
    }

    public string FuckMyAssAction()
    {
        return "This is the defaut return action that you get";
    }


    public string Index()
    {
        _logger.LogInformation("This is a log statement");

        return "This is the homepage";
    }


    public ActionResult<string> Test()
    {
        return "Test is succesfull";
    }
}