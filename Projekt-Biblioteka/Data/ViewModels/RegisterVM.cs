using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Adres Email")]
        [Required(ErrorMessage = "Adres Email jest wymagany")]
        public string EmailAddress { get; set; }

        [Display(Name = "Hasło")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [Required(ErrorMessage = "Potwiedzenie hasła jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }
        
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [Display(Name = "PESEL")]
        [Required(ErrorMessage = "Numer PESEL jest wymagany")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Nieprawidłowy numer PESEL")]
        public string PESEL { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres jest wymaganyy")]
        public string Address { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Miasto jest wymagane")]
        public string City { get; set; }

        [Display(Name = "Kod Pocztowy")]
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Prawidłowy format kodu pocztowego to XX-XXX")]
        public string PostalCode { get; set; }
    }
}
