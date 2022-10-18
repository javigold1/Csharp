using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Count = 1;

            var newStr = "";
            for (var i = 0; i < 14; i++)
            {
                var Str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var randomStr = rand.Next(0, Str.Length);
                newStr += Str[randomStr];
            }
            ViewBag.Password = newStr;
            return View();
        }

        Random rand = new Random();
        public IActionResult Generate()
        {
            if (HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 2);
                int? IntVariable = HttpContext.Session.GetInt32("count");
                ViewBag.Count = HttpContext.Session.GetInt32("count");

                var newStr = "";
                for (var i = 0; i < 14; i++)
                {
                    var Str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var randomStr = rand.Next(0, Str.Length);
                    newStr += Str[randomStr];
                }
                ViewBag.Password = newStr;

            }
            else
            {
                int? IntVariable = HttpContext.Session.GetInt32("count");
                IntVariable++;
                HttpContext.Session.SetInt32("count", (int)IntVariable);
                ViewBag.Count = HttpContext.Session.GetInt32("count");

                var newStr = "";
                for (var i = 0; i < 14; i++)
                {
                    var Str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var randomStr = rand.Next(0, Str.Length);
                    newStr += Str[randomStr];
                }
                ViewBag.Password = newStr;
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}