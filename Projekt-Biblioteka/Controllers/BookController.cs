using Projekt_Biblioteka.Data.Services;
using Projekt_Biblioteka.Data.ViewModels;
using Projekt_Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_Biblioteka.Data.Static;
using Microsoft.AspNetCore.Authorization;

namespace Projekt_Biblioteka.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllBooksAsync();
            
            return View(allBooks);
        }

        //Filter
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllBooksAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allBooks.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Authors_Books.Select(n => n.Author.FullName.ToLower()).Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allBooks);
        }

        //GET: Book/Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            return View(bookDetails);
        }

        //GET: Book/Create
        public async Task<IActionResult> CreateAsync()
        {
            var bookDropDown = await _service.GetNewBookDropdownsValues();

            ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropDown = await _service.GetNewBookDropdownsValues();

                ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
                ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
                ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");

                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //GET: Book/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                RelaseDate = bookDetails.RelaseDate,
                ImageURL = bookDetails.ImageURL,
                ISBN = bookDetails.ISBN,
                IsBorrowed = bookDetails.IsBorrowed,
                CategoryId = bookDetails.CategoryId,
                PublisherId = bookDetails.PublisherId,
                AuthorId = bookDetails.Authors_Books.Select(n => n.AuthorId).ToList(),
            };

            var bookDropDown = await _service.GetNewBookDropdownsValues();
            ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropDown = await _service.GetNewBookDropdownsValues();
                ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
                ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
                ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");
                return View(movie);
            }

            await _service.UpdateBookAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Book/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                RelaseDate = bookDetails.RelaseDate,
                ImageURL = bookDetails.ImageURL,
                ISBN = bookDetails.ISBN,
                IsBorrowed = bookDetails.IsBorrowed,
                CategoryId = bookDetails.CategoryId,
                PublisherId = bookDetails.PublisherId,
                AuthorId = bookDetails.Authors_Books.Select(n => n.AuthorId).ToList(),
            };

            var bookDropDown = await _service.GetNewBookDropdownsValues();
            ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");

            return View(response);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                RelaseDate = bookDetails.RelaseDate,
                ImageURL = bookDetails.ImageURL,
                ISBN = bookDetails.ISBN,
                IsBorrowed = bookDetails.IsBorrowed,
                CategoryId = bookDetails.CategoryId,
                PublisherId = bookDetails.PublisherId,
                AuthorId = bookDetails.Authors_Books.Select(n => n.AuthorId).ToList(),
            };

            var bookDropDown = await _service.GetNewBookDropdownsValues();
            ViewBag.Authors = new SelectList(bookDropDown.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(bookDropDown.Publishers, "Id", "Name");
            ViewBag.Categories = new SelectList(bookDropDown.Categories, "Id", "Name");

            await _service.DeleteNewBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
