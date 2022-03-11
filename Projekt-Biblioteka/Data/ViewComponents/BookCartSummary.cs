using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_Biblioteka.Data.Cart;

namespace Projekt_Biblioteka.Data.ViewComponents
{
    public class BookCartSummary : ViewComponent
    {
        private readonly BookCart _bookCart;
        public BookCartSummary(BookCart bookCart)
        {
            _bookCart = bookCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _bookCart.GetBookCartItems();

            return View(items.Count);
        }
    }
}
