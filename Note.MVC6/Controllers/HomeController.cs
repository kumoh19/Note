using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Note.BLL;
using Note.MVC6.Models;
using System.Diagnostics;

namespace Note.MVC6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserBll _userBll;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public HomeController(ILogger<HomeController> logger, UserBll userBll)  //생성자를 통한 접근
        {
            _logger = logger;
            _userBll = userBll;
        }

        public IActionResult Index()
        {
            var user = _userBll.GetUser(1);
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