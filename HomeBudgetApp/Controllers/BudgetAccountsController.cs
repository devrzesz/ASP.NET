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
            var viewModel = CreateAccountViewModel();
            return View("Form", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var viewModel = CreateAccountViewModel((int)id);

            if (viewModel.Account == null)
                return HttpNotFound();

            return View("Form", viewModel);
        }

        [HttpGet]
        public void Delete(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Id == id);

            if (account == null)
                return;

            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = CreateAccountViewModel(account.Id);
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

        [NonAction]
        private AccountFormViewModel CreateAccountViewModel(int id = 0)
        {
            Account account;

            if (id == 0)
                account = new Account();
            else
                account = _context.Accounts.Single(a => a.Id == id);

            var viewModel = new AccountFormViewModel()
            {
                Account = account,
                AccountTypes = _context.AccountTypes.ToList(),
            };

            return viewModel;
        }
    }
}