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

    [Route("{controllerName}")]
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

        [HttpGet("BookDescription")]
        public IActionResult BookDescription([FromQuery] int bookId)
        {
            // Найти книгу по id
            // Book book = books.Find(b => b.Id == bookId);
            // В ViewBag установить sellerId, которому соответствует заданная книга
            // ViewBag.sellerId = sellers.Find(seller => seller.Books.Exists(book => book.Id == bookId)).UserId;
            return View(/*передать Book*/);
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

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddBookPost([FromForm] Book book)
        {
            // Не забыть также добавить эту книгу продавцу
            var result = this.bookService.AddBook(book);
            if (!result)
            {
                return RedirectToAction("AddBook");
            }
            return RedirectToAction("GetAllBooks");
        }

        [HttpGet("view-orders")]
        [Authorize(Roles = "seller")]
        public IActionResult ViewOrders()
        {
            // Получить sellerId(userId) из HttpContext
            // Найти список заказов для этого sellerId
            // List<Order> orderListforUser = orders.Where(order => order.Seller.UserId == sellerId).ToList();
            return View(/*передать List<Order>*/);
        }

        [HttpPost("order-action")]
        [Authorize(Roles = "seller")]
        public IActionResult OrderAction(string orderId, string actionType)
        {
            if (actionType == "Подтвердить")
            {
                // Получить order по orderId
                // Найти книгу из списка книг по order.Book.Id
                // Уменьшить BookCount этой книги
                // Удалить заказ из списка заказов
                return Ok("Заказ подтверждён");
            }
            if (actionType == "Отклонить")
            {
                // Получить order по orderId
                // Удалить заказ из списка заказов
                return Ok("Заказ удалён");
            }
            return Ok("Заказ отклонён");
        }

        [HttpPost("book-action")]
        [Authorize]
        public IActionResult BookAction(string actionType, Book book, string sellerId)
        {
            if (actionType == "Купить")
            {
                //sellerId есть, bookId есть, customerId - взять из HttpContext. Сгенерировать order
                return Ok($"Книга с id {book.Id} успешно добавлена заказана. Ожидайте подтвердения продавца");
            }
            if (actionType == "Удалить")
            {
                return Ok($"Книга с id {book.Id} успешно удалена");
            }
            return Ok();
        }
    }
}
