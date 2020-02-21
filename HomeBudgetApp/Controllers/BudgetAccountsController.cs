using HomeBudgetApp.Models;
using HomeBudgetApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudgetApp.Controllers
{
    public class BudgetAccountsController : BaseController
    {
        public ActionResult Index()
        {
            IEnumerable<Account> accounts;

            try
            {
                accounts = _context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }

            return View(accounts);
        }

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new AccountFormViewModel()
            {
                Account = new Account(),
                AccountTypes = _context.AccountTypes.ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (!ModelState.IsValid)
               return RedirectToAction("New");

            account.Balance = account.OpeningBalance;

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}