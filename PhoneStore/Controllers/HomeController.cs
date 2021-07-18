using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;

        public HomeController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }


        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.PhoneId = id;

            return View();
        }


        [HttpPost]
        public IActionResult Buy(Order order)
        {
            db.Orders.Add(order);

            db.SaveChanges();

            return View("Thanks");
        }


    }
}
