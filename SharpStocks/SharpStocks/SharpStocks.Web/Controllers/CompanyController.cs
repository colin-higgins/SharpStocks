using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using SharpStocks.Data;
using SharpStocks.Web.ViewModels;

namespace SharpStocks.Web.Controllers
{
    public class CompanyController : Controller
    {
        private SharpStocksContext _context;

        public CompanyController()
        {
            _context = new SharpStocksContext();
        }

        [HttpGet]
        public ActionResult Edit(string symbol)
        {
            if (String.IsNullOrEmpty(symbol))
                return View(new CompanyViewModel());

            var company = _context.Companies.FindCompanyBySymbol(symbol);

            company = company ?? new Company() { Symbol = symbol };

            var model = new CompanyViewModel(company);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CompanyViewModel model)
        {
            var company = _context.Companies.FindCompanyBySymbol(model.Symbol);

            company = company ?? new Company();

            company.Id = model.Id ?? new Oid();
            company.Name = model.Name;
            company.Description = model.Description;
            company.Symbol = model.Symbol;
            company.StockExchange = model.StockExchange;
            company.Sector = model.Sector;

            _context.Companies.Save(company);

            return RedirectToAction("Edit", new { model.Symbol });
        }

        public ActionResult Oops(string symbol)
        {
            return View(symbol);
        }

        [HttpGet]
        public ActionResult Detail(string symbol)
        {
            var company = (Company) null;

            if (!String.IsNullOrEmpty(symbol))
                company = _context.Companies.FindCompanyBySymbol(symbol);

            if (company == null)
                return RedirectToAction("Oops", new { symbol });

            return View(company);
        }

        public ActionResult Search()
        {
            var companyFilter = new Company();

            var companies = _context.Companies.GetCompanies(companyFilter).ToList();

            return View(companies);
        }
    }
}