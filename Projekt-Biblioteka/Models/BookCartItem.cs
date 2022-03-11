using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class BookCartItem
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
        public int Amount { get; set; }
        public string BookCartId { get; set; }
    }
}
