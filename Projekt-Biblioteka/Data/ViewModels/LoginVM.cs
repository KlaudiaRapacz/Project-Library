using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adres Email")]
        [Required(ErrorMessage = "Adres Email jest wymagany")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
