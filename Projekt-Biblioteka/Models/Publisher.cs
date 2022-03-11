using Projekt_Biblioteka.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class Publisher : IEntityBase
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Wydawnictwo")]
        [Required(ErrorMessage = "Nazwa wydawnictwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }
        
        [Display(Name = "Zdjęcie")]
        public string ImageURL { get; set; }

        //Relationships
        public virtual ICollection<Book> Books { get; set; }
    }
}
