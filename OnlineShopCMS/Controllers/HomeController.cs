using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopCMS.Areas.Identity.Data;
using OnlineShopCMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShopCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<OnlineShopUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<OnlineShopUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public class dataclass
        {
            public string label { get; set; }
            public int data { get; set; }
            public string backgroundColor { get; set; }

        }


        public IActionResult Dashboard()
        {
            var userdata = _userManager.Users.ToList();
            ViewBag.Userdata = JsonSerializer.Serialize(userdata);

            List<string> labellist = new List<string>();
            List<int> datalist = new List<int>();

            var mydata = _userManager.Users.GroupBy(m => m.Gender).Select(x => new { label = x.Key, data = x.Count() }).ToList();

            foreach(var item in mydata)
            {
                labellist.Add(item.label.ToString());
                datalist.Add(item.data);
            }
            ViewBag.mylabel = JsonSerializer.Serialize(labellist);
            ViewBag.mydata = JsonSerializer.Serialize(datalist);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Demo()
        {
            return View("Hello World");
        }
    }
}
