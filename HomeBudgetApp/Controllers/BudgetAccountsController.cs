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



        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AccountFormViewModel()
                {
                    Account = account,
                    AccountTypes = _context.AccountTypes.ToList(),
                };

                return View("Form", viewModel);
            }

            if (account.Id == 0)
            {
                account.Balance = account.OpeningBalance;
                _context.Accounts.Add(account);
                TempData["Msg"] = "Successfully account created";
            }
            else
            {
                var accountDb = _context.Accounts.Single(a => a.Id == account.Id);
                accountDb.Name = account.Name;
                accountDb.OpeningBalance = account.OpeningBalance;
                accountDb.TypeId = account.TypeId;
                TempData["Msg"] = "Successfully account updated";
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new AccountFormViewModel()
            {
                Account = new Account(),
                AccountTypes = _context.AccountTypes.ToList(),
            };

            ViewData["Title"] = "New account";
            return View("Form", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var accountDB = _context.Accounts.SingleOrDefault(a => a.Id == id);
            var accountTypes = _context.AccountTypes.ToList();

            if (accountDB == null)
                return HttpNotFound();

            var viewModel = new AccountFormViewModel()
            {
                Account = accountDB,
                AccountTypes = accountTypes,
            };

            ViewData["Title"] = $"Edit account - {accountDB.Name}";
            return View("Form", viewModel);
        }
    }
}