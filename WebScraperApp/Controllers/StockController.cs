using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScraperApp.Models;

namespace WebScraperApp.Controllers
{

    public class StockController : Controller
    {
        // Get Stocks
        public IActionResult Index()
        {
        return View();
        }
   
    }
}