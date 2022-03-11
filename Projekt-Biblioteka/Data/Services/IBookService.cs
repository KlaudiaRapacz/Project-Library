using Projekt_Biblioteka.Data.Base;
using Projekt_Biblioteka.Data.ViewModels;
using Projekt_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Services
{
    public interface IBookService : IEntityBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<NewDropDownVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
        Task DeleteNewBookAsync(int id);
    }
}
