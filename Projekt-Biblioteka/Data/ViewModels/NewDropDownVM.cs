using Projekt_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.ViewModels
{
    public class NewDropDownVM
    {
        public NewDropDownVM()
        {
            Authors = new List<Author>();
            Publishers = new List<Publisher>();
            Categories = new List<Category>();
        }

        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Category> Categories { get; set; }
    }
}

