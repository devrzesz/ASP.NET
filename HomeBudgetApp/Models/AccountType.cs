using System.ComponentModel.DataAnnotations;

namespace HomeBudgetApp.Models
{
    public class AccountType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}