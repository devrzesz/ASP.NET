using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBudgetApp.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        [Display(Name="Opening Balance")]
        public decimal OpeningBalance { get; set; }

        public int TypeId { get; set; }
        public AccountType Type { get; }


    }
}