using HomeBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudgetApp.Controllers
{
    public class BudgetAccountsController : BaseController
    {
        // GET: BudgetAccounts
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
    }
}