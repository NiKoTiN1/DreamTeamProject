using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DreamTeamProject.Web.Controllers
{

    [Route("{controllerName}")]
    public class BookController : Controller
    {

        List<Book> books = new List<Book>();

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
            books.AddRange(new Book[] {
                new Book{
                    Id = 1,
                    Name = "Book 1",
                    NumberOfPages = 54,
                    Price = 100,
                    PublishingHouse = new PublishingHouse {
                        Id = 1,
                        Name = "Publishing house 1",
                        Email = "pubhouse1@somemail.com",
                        Address = "Address 1"
                    }
                },
                new Book{
                    Id = 2,
                    Name = "Book 2",
                    NumberOfPages = 86,
                    Price = 120,
                    PublishingHouse = new PublishingHouse {
                        Id = 2,
                        Name = "Publishing house 2",
                        Email = "pubhouse2@somemail.com",
                        Address = "Address 2"
                    }
                },
                new Book{
                    Id = 3,
                    Name = "Book 3",
                    NumberOfPages = 115,
                    Price = 55,
                    PublishingHouse = new PublishingHouse {
                        Id = 3,
                        Name = "Publishing house 3",
                        Email = "pubhouse3@somemail.com",
                        Address = "Address 3"
                    }
                },
                new Book{
                    Id = 4,
                    Name = "Book 4",
                    NumberOfPages = 535,
                    Price = 112,
                    PublishingHouse = new PublishingHouse {
                        Id = 1,
                        Name = "Publishing house 1",
                        Email = "pubhouse1@somemail.com",
                        Address = "Address 1"
                    }
                },
                new Book{
                    Id = 5,
                    Name = "Book 5",
                    NumberOfPages = 89,
                    Price = 36,
                    PublishingHouse = new PublishingHouse {
                        Id = 3,
                        Name = "Publishing house 3",
                        Email = "pubhouse3@somemail.com",
                        Address = "Address 3"
                    }
                },

            });
        }

        private readonly IBookService bookService;

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return View(books);
        }

        [HttpGet("BookDescription")]
        public IActionResult BookDescription([FromQuery] int bookId)
        {
            Book book = books.Find(b => b.Id == bookId);
            return View(book);
        }
    }
}
