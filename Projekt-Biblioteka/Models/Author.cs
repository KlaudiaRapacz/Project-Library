using Projekt_Biblioteka.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class Author : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Author jest wymagany")]
        public string FullName { get; set; }

        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "Biografia jest wymagana")]
        public string Bio { get; set; }

        [Display(Name = "Zdjęcie")]
        public string ImageURL { get; set; }


        //Relationships
        public virtual ICollection<Author_Book> Authors_Books { get; set; }
    }
}
