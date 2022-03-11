using Projekt_Biblioteka.Data.Cart;
using Projekt_Biblioteka.Data.Services;
using Projekt_Biblioteka.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Projekt_Biblioteka.Data.Static;

namespace Projekt_Biblioteka.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBookService _bookService;
        private readonly BookCart _bookCart;
        private readonly IOrderService _orderService;

        public OrderController(IBookService bookService, BookCart bookCart, IOrderService orderService)
        {
            _bookService = bookService;
            _bookCart = bookCart;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        
        //BookCart
        public IActionResult BookCart()
        {
            var items = _bookCart.GetBookCartItems();
            _bookCart.BookCartItems = items;

            var response = new BookCartVM()
            {
                bookCart = _bookCart
            };

            return View(response);
        }
        //Add item
        public async Task<RedirectToActionResult> AddItemToBookCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);

            if (item != null)
            {
                _bookCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(BookCart));
        }
        //Remove item
        public async Task<IActionResult> RemoveItemFromBookCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);

            if (item != null)
            {
                _bookCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(BookCart));
        }

        //CompleteOrder
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _bookCart.GetBookCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _bookCart.ClearBookCartAsync();
            foreach (var borrow in items)
            {
                await _bookCart.BorrowedStatus(borrow);
            }

            return View("CompleteOrder");
        }
    }
}
