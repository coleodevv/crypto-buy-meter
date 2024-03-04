using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stockbuysellbackendapi.Models;


namespace stockbuysellbackendapi.Controllers;


public class HomeController : Controller
{
    public ActionResult<string> HomePage()
    {
        return "Welcome to the homepage";
    }

}