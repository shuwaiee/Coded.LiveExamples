using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Models
{
    public class EditFormModel
    {
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class AddEmployeeForm
    {
        [EmailAddress] 
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BankId { get; set; }
    }
}
