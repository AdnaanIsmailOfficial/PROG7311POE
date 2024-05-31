using Microsoft.AspNetCore.Mvc;
using PROG7311POE.Models;
using System.Diagnostics;

/***************************
 *Code attribution 
 *Author:Ebrahim Adam (Varsity college)
 *Date:2023
***************************/

/***************************
 *Code attribution 
 *Author:Serina (Varsity college)
 *Date:2023
***************************/

/**************************
 *Code attribution
 *Author:Digital TechJoint
 *Link:https://www.youtube.com/watch?v=ghzvSROMo_M
 *Date:26 October 2022
 ***************************/

/**************************
 *Code attribution
 *Author:Chen
 *Link:https://stackoverflow.com/questions/72848070/login-page-with-asp-net-core-mvc
 *Date:04 July 2022
 ***************************/



namespace PROG7311POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}