using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpStocks.Data;
using SharpStocks.Web.ViewModels;
using StockService;

namespace SharpStocks.Web.Controllers
{
    public class HomeController : Controller
    {
        private SharpStocksContext _context;

        public HomeController()
        {
            _context = new SharpStocksContext();
        }

        public ActionResult Index()
        {
            var service = new QuoteService();

            var quotes = service.Test();

            var context = new SharpStocksContext();

            ViewBag.Quotes = quotes;

            return View();
        }
    }
}