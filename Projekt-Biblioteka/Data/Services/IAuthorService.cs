using Projekt_Biblioteka.Data.Base;
using Projekt_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Services
{
    public interface IAuthorService : IEntityBaseRepository<Author>
    {
        Task<Author> GetAuthorByIdAsync(int id);
    }
}
