using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBudgetApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter category' name.")]
        public string Name { get; set; }

        public IEnumerable<Category> SubCategories { get; set; }
    }
}