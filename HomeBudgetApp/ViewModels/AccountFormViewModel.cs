using HomeBudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudgetApp.ViewModels
{
    public class AccountFormViewModel
    {
        public Account Account { get; set; }
        public IEnumerable<AccountType> AccountTypes{ get; set; }
    }
}