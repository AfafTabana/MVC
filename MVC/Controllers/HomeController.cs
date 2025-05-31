using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult ShowView()
        {
            ViewResult result = new ViewResult();

            result.ViewName = "View1";

            return result;
        }

        public IActionResult ShowMix(int id) {
        
            if(id %2 ==0 )
            {
                return ShowView(); 
            } else

            {
                return ShowContent();
            }
        }
        public ContentResult ShowContent() {
        
            ContentResult result = new ContentResult();
            result.Content = "Hello"; 
            return result;
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
