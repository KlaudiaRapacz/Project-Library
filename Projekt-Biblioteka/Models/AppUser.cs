using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        
        [Display(Name = "Adres")]
        public string Address { get; set; }
        
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        
        [Display(Name = "Miasto")]
        public string City { get; set; }
        
        [Display(Name = "PESEL")]
        public string PESEL { get; set; }
    }
}
