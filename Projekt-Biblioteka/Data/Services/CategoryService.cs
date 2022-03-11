using Projekt_Biblioteka.Data.Base;
using Projekt_Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var categoryDetails = await _db.Categories
                .Include(b => b.Books)
                .ThenInclude(ab => ab.Authors_Books)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);
            return categoryDetails;
        }

    }
}
