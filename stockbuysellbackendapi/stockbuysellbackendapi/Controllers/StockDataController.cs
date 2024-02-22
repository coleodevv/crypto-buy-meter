using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{

    [ApiController]
/*This creates all connection urls to default to the controller name in this case StockDataController so you dont need to specify that in every route above your actions anymore*/
    [Route("[controller]")]
    public class StockDataController : ControllerBase
    {
        /*
        private readonly ILogger<StockDataController> _ilogger;


        public StockDataController(ILogger<StockDataController> logger)
        {
            _ilogger = logger;
        }

        private readonly int rareId = 10;
        */


/*There is no need to specify the controller name since we are using a default*/
        [Route("SayGoodbye")]
        public ActionResult<string> SayGoodbye()
        {

            return "Toodaloo!";
        }

        /*
        public void TalkToRouteController()
        {
            _ilogger.LogInformation("This is the info you were looking for");
        }
    */
    }
}