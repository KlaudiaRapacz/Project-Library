using Projekt_Biblioteka.Data.Base;
using Projekt_Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        private readonly AppDbContext _db;
        public AuthorService(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var authorDetails = await _db.Authors
                .Include(a => a.Authors_Books)
                .ThenInclude(b => b.Book)
                .ThenInclude(ab => ab.Authors_Books)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);
            return authorDetails;
        }
    }
}
