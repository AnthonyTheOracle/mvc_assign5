using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_assign5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace mvc_assign5.Controllers
{
    public class HomeController : Controller
    {
        private SettlementContext context { get; set; }

        public HomeController(SettlementContext ctx)
        {
            context = ctx;
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Save";
            var state = context.States.Find(id);

            return View(state);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Settlement(string vState)
        {
            ViewBag.Action = "Settlement";
            //ViewBag.vAmount = 
            //List<Settlement> settlements = context.Settlements.OrderBy(s => s.vState).ToList();
            var settlements = context.Settlements.OrderBy(s => s.vState).ToList();
            return View(settlements);
        }
        [HttpGet]
        public IActionResult State() 
        {
            var states = context.States.OrderBy(s => s.vStateName).ToList();
            return View(states);
        }

        public IActionResult SettlementDetail()
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
