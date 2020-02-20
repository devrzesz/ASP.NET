using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudgetApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; }
        public decimal Balance { get; set; }
        public decimal OpeningBalance { get; set; }

        public Account(decimal openingBalance)
        {
            OpeningBalance = openingBalance = Balance;
        }
    }
}