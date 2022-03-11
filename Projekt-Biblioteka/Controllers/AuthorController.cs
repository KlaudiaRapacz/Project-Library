using Projekt_Biblioteka.Data.Services;
using Projekt_Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_Biblioteka.Data.Static;
using Microsoft.AspNetCore.Authorization;

namespace Projekt_Biblioteka.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAuthors = await _service.GetAllAsync();
            return View(allAuthors);
        }

        //GET: author/details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        //GET: author/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageURL,FullName,Bio")] Author author)
        {
            if (!ModelState.IsValid) return View(author);

            await _service.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        //GET: author/edit
        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _service.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (!ModelState.IsValid) return View(author);

            if (id == author.Id)
            {
                await _service.UpdateAsync(id, author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //GET: author/delete
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var authorDetails = await _service.GetAuthorByIdAsync(id);
            if (authorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
