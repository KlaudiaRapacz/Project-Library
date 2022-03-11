using Projekt_Biblioteka.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Data.Cart
{
    public class BookCart
    {
        public AppDbContext _db { get; set; }

        public string BookCartId { get; set; }
        public List<BookCartItem> BookCartItems { get; set; }

        public BookCart(AppDbContext db)
        {
            _db = db;
        }

        public List<BookCartItem> GetBookCartItems()
        {
            return BookCartItems ?? (BookCartItems = _db.BookCartItems.Where(n => n.BookCartId == BookCartId).Include(n => n.Book).ToList());
        }

        public static BookCart GetBookCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var db = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new BookCart(db) { BookCartId = cartId };
        }
        //Add item
        public void AddItemToCart(Book book)
        {
            var bookCartItem = _db.BookCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.BookCartId == BookCartId);

            if (bookCartItem == null)
            {
                bookCartItem = new BookCartItem()
                {
                    BookCartId = BookCartId,
                    Book = book,
                    Amount = 1
                };

                _db.BookCartItems.Add(bookCartItem);
            }
            _db.SaveChanges();
        }

        //Remove item
        public void RemoveItemFromCart(Book book)
        {
            var bookCartItem = _db.BookCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.BookCartId == BookCartId);

            if (bookCartItem != null)
            {
                if (bookCartItem.Amount > 1)
                {
                    bookCartItem.Amount--;
                }
                else
                {
                    _db.BookCartItems.Remove(bookCartItem);
                }
            }
            _db.SaveChanges();
        }

        public async Task ClearBookCartAsync()
        {
            var items = await _db.BookCartItems.Where(n => n.BookCartId == BookCartId).ToListAsync();
            _db.BookCartItems.RemoveRange(items);

            
        }

        public async Task BorrowedStatus(BookCartItem borrow)
        {
            var status = _db.Books.Where(m => m.IsBorrowed == false).FirstOrDefault(n => n.Id == borrow.Book.Id );
            status.IsBorrowed = true;

            await _db.SaveChangesAsync();
        }
    }
}

