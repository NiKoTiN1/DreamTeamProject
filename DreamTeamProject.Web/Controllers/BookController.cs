using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetSearchedBooks([FromRoute] string searchLine)
        {
            SearchViewModel model = new SearchViewModel()
            {
                SearchedByAuthor = this.bookService.GetBookByAuthor(searchLine),
                SearchedByBookName = this.bookService.GetBookByName(searchLine),
                SearchedByGenere = this.bookService.GetBookByGenere(searchLine)
            };
            return View(model);
        }

        [HttpGet]
        [Authorize]
        [Route("add")]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddBookPost([FromForm] Book book)
        {
            var result = this.bookService.AddBook(book);
            if(!result)
            {
                return RedirectToAction("AddBook");
            }
            return RedirectToAction("GetAllBooks");
        }

        [HttpGet]
        [Authorize]
        [Route("add-genere")]
        public IActionResult AddGenere()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public IActionResult AddGenerePost([FromForm] string genere)
        {
            var result = this.bookService.AddGenere(genere);
            if (!result)
            {
                return RedirectToAction("AddGenere");
            }
            return RedirectToAction("GetAllBooks");
        }

        [HttpGet]
        [Authorize]
        [Route("add-pub-house")]
        public IActionResult AddPubHouse()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public IActionResult AddPubHousePost([FromForm] string name)
        {
            return RedirectToAction("GetAllBooks");
        }
    }
}
