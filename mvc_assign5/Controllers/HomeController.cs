using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_assign5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace mvc_assign5.Controllers
{
    public class HomeController : Controller
    {
        private SettlementContext context { get; set; }

        [HttpGet]
        public IActionResult Agriculture()
        {
            string uri = "http://quickstats.nass.usda.gov/api/api_GET/?key=D5739166-891A-355D-ADCA-34890CC7AED6&commodity_desc=TOBACCO&unit_desc=ACRES&year=2021";
            string results = "";
            AgricultureCollection results_Obj;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                results = reader.ReadToEnd();
                results_Obj = JsonConvert.DeserializeObject<AgricultureCollection>(results);
            }

            Dictionary<string, int> groupedChartData = new Dictionary<string, int>();
            NumberStyles styles = NumberStyles.AllowThousands;

            foreach( Agriculture ag in results_Obj.data)
            {
                if (groupedChartData.ContainsKey(ag.state_alpha))
                {
                    int val = groupedChartData[ag.state_alpha];
                    val = val + int.Parse(ag.Value, styles);
                } 
                else
                {
                    groupedChartData.Add(ag.state_alpha, int.Parse(ag.Value, styles));
                }
            }
            results_Obj.groupedChartData = groupedChartData.ToList();

            return View(results_Obj);
        }

        public HomeController(SettlementContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new State());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var state = context.States.Find(id);

            return View(state);
        }
        [HttpPost]
        public IActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                if (state.StateID == 0)
                    context.States.Add(state);
                else
                    context.States.Update(state);
                context.SaveChanges();
                return RedirectToAction("State", "Home");
            }
            else
            {
                ViewBag.Action = (state.StateID == 0) ? "Add" : "Edit";
                return View(state);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = context.States.Find(id);
            return View(state);
        }

        [HttpPost]
        public IActionResult Delete(State state)
        {
            context.States.Remove(state);
            context.SaveChanges();
            return RedirectToAction("State", "Home");
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
