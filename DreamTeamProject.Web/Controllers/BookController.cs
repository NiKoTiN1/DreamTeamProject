using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DreamTeamProject.Web.Controllers
{
    public class BookController : Controller
    {
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        private readonly IBookService bookService;

        public IActionResult GetAllBooks()
        {
            List<Book> books = new List<Book>();
            return View(books);
        }
    }
}
