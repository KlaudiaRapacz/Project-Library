using Projekt_Biblioteka.Data.Base;
using Projekt_Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Services
{
    public class PublisherService : EntityBaseRepository<Publisher>, IPublisherService
    {
        private readonly AppDbContext _db;
        public PublisherService(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            var bookDetails = await _db.Publishers
                .Include(b => b.Books)
                .ThenInclude(ab => ab.Authors_Books)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);
            return bookDetails;
        }
    }
}
