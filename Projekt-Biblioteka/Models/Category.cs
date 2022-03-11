using Projekt_Biblioteka.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa Kategorii jest wymagana!")]
        public string Name { get; set; }

        //Relationships
        public virtual ICollection<Book> Books { get; set; }
    }
}
