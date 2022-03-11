using Projekt_Biblioteka.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool IsBorrowed { get; set; }
        public string ISBN { get; set; }



        //Relationships
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        public virtual ICollection <Author_Book> Authors_Books { get; set; }



    }
}
