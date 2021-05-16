using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DreamTeamProject.Web.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        private readonly IBookService bookService;


        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBooks()
        {
            List<Book> books = this.bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        [Route("search/{searchLine}")]
        public IActionResult GetAllBooks([FromRoute] string searchLine)
        {
            SearchViewModel model = new SearchViewModel()
            {
                SearchedByAuthor = this.bookService.GetBookByAuthor(searchLine),
                SearchedByBookName = this.bookService.GetBookByName(searchLine),
                SearchedByGenere = this.bookService.GetBookByGenere(searchLine)
            };
            return View(model);
        }
    }
}
