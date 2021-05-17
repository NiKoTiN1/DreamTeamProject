using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DreamTeamProject.Web.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {

        public BookController(IBookService bookService, IAccountService accountService)
        {
            this.bookService = bookService;
            this.accountService = accountService;
        }

        private readonly IBookService bookService;
        private readonly IAccountService accountService;


        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBooks()
        {
            List<Book> books = this.bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        [Route("{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            var book = this.bookService.GetBook(bookId);
            if (book == null)
            {
                return RedirectToAction("GetAllBooks");
            }
            return View(book);
        }

        [HttpPost("add-comment")]
        [Authorize]
        public IActionResult AddComment(AddCommnetViewModel model)
        {
            // UserId получи из claims
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var result = this.bookService.AddBookComment(model.Context, model.UserId, model.BookId);
            if (!result)
            {
                return RedirectToAction("GetAllBooks");
            }
            return RedirectToAction("GetBook", model.BookId);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult GetSearchedBooks(string searchLine)
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

        [HttpPost("add")]
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

        [HttpPost("delete")]
        [Authorize]
        public IActionResult DeleteBook(string bookId)
        {
            // Добавить логику удаления
            return Ok();
        }
    }
}
