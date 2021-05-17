using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeamProject.Services.Services
{
    public class BookService : IBookService
    {
        public BookService(IBookReposetory bookReposetory)
        {
            this.bookReposetory = bookReposetory;
        }

        private readonly IBookReposetory bookReposetory;

        public List<Book> GetAllBooks()
        {
            var dbResult = this.bookReposetory.GetAllBooks();
            if(dbResult.Result == DbResult.Faild)
            {
                return null;
            }
            List<Book> books = new List<Book>();
            for (int i = 0; i < dbResult.OutElements.Count; i += 10)
            {
                Book book = new Book()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i)),
                    Name = dbResult.OutElements.ElementAt(i + 1).ToString(),
                    NumberOfPages = dbResult.OutElements.ElementAt(i + 2).ToString(),
                    Price = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 3)),
                    BookCount = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 4)),
                    Author = new Author()
                    {
                        SurName = dbResult.OutElements.ElementAt(i + 5).ToString(),
                        Name = dbResult.OutElements.ElementAt(i + 6).ToString(),
                        MiddleName = dbResult.OutElements.ElementAt(i + 7).ToString(),
                    },
                    PublishingHouse = new PublishingHouse()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 8).ToString()
                    },
                    Genere = new Genere()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 9).ToString()
                    }
                };
                books.Add(book);
            }
            return books;
        }

        public List<Book> GetBookByAuthor(string authorName)
        {
            var dbResult = this.bookReposetory.GetBookByAuthor(authorName);
            if (dbResult.Result == DbResult.Faild)
            {
                return null;
            }
            List<Book> books = new List<Book>();
            for (int i = 0; i < dbResult.OutElements.Count; i += 10)
            {
                Book book = new Book()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i)),
                    Name = dbResult.OutElements.ElementAt(i + 1).ToString(),
                    NumberOfPages = dbResult.OutElements.ElementAt(i + 2).ToString(),
                    Price = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 3)),
                    BookCount = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 4)),
                    Author = new Author()
                    {
                        SurName = dbResult.OutElements.ElementAt(i + 5).ToString(),
                        Name = dbResult.OutElements.ElementAt(i + 6).ToString(),
                        MiddleName = dbResult.OutElements.ElementAt(i + 7).ToString(),
                    },
                    PublishingHouse = new PublishingHouse()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 8).ToString()
                    },
                    Genere = new Genere()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 9).ToString()
                    }
                };
                books.Add(book);
            }
            return books;
        }

        public List<Book> GetBookByName(string bookName)
        {
            var dbResult = this.bookReposetory.GetBookByName(bookName);
            if (dbResult.Result == DbResult.Faild)
            {
                return null;
            }
            List<Book> books = new List<Book>();
            for (int i = 0; i < dbResult.OutElements.Count; i += 10)
            {
                Book book = new Book()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i)),
                    Name = dbResult.OutElements.ElementAt(i + 1).ToString(),
                    NumberOfPages = dbResult.OutElements.ElementAt(i + 2).ToString(),
                    Price = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 3)),
                    BookCount = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 4)),
                    Author = new Author()
                    {
                        SurName = dbResult.OutElements.ElementAt(i + 5).ToString(),
                        Name = dbResult.OutElements.ElementAt(i + 6).ToString(),
                        MiddleName = dbResult.OutElements.ElementAt(i + 7).ToString(),
                    },
                    PublishingHouse = new PublishingHouse()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 8).ToString()
                    },
                    Genere = new Genere()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 9).ToString()
                    }
                };
                books.Add(book);
            }
            return books;
        }

        public List<Book> GetBookByGenere(string genereName)
        {
            var dbResult = this.bookReposetory.GetBookByGenere(genereName);
            if (dbResult.Result == DbResult.Faild)
            {
                return null;
            }
            List<Book> books = new List<Book>();
            for (int i = 0; i < dbResult.OutElements.Count; i += 10)
            {
                Book book = new Book()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i)),
                    Name = dbResult.OutElements.ElementAt(i + 1).ToString(),
                    NumberOfPages = dbResult.OutElements.ElementAt(i + 2).ToString(),
                    Price = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 3)),
                    BookCount = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 4)),
                    Author = new Author()
                    {
                        SurName = dbResult.OutElements.ElementAt(i + 5).ToString(),
                        Name = dbResult.OutElements.ElementAt(i + 6).ToString(),
                        MiddleName = dbResult.OutElements.ElementAt(i + 7).ToString(),
                    },
                    PublishingHouse = new PublishingHouse()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 8).ToString()
                    },
                    Genere = new Genere()
                    {
                        Name = dbResult.OutElements.ElementAt(i + 9).ToString()
                    }
                };
                books.Add(book);
            }
            return books;
        }

        public bool AddBook(Book book)
        {
            var dbResult = this.bookReposetory.AddBook(book);
            return dbResult.Result == DbResult.Successed;
        }

        public bool AddGenere(string genereName)
        {
            var dbResult = this.bookReposetory.AddGenere(genereName);
            return dbResult.Result == DbResult.Successed;
        }

        public bool AddPubHouse(string name)
        {
            var dbResult = this.bookReposetory.AddPubHouse(name);
            return dbResult.Result == DbResult.Successed;
        }

        public GetBookViewModel GetBook(int bookId)
        {
            var dbResult = this.bookReposetory.GetBook(bookId);
            GetBookViewModel model = new GetBookViewModel()
            {
                Book = new Book()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(0)),
                    Name = dbResult.OutElements.ElementAt(1).ToString(),
                    NumberOfPages = dbResult.OutElements.ElementAt(2).ToString(),
                    Price = Convert.ToInt32(dbResult.OutElements.ElementAt(3)),
                    BookCount = Convert.ToInt32(dbResult.OutElements.ElementAt(4)),
                    Author = new Author()
                    {
                        SurName = dbResult.OutElements.ElementAt(5).ToString(),
                        Name = dbResult.OutElements.ElementAt(6).ToString(),
                        MiddleName = dbResult.OutElements.ElementAt(7).ToString(),
                    },
                    PublishingHouse = new PublishingHouse()
                    {
                        Name = dbResult.OutElements.ElementAt(8).ToString()
                    },
                    Genere = new Genere()
                    {
                        Name = dbResult.OutElements.ElementAt(9).ToString()
                    }
                },
                Comments = new List<Comment>()
            };
            var commentDbResult = this.bookReposetory.GetBookComments(bookId);
            if(commentDbResult.Result == DbResult.Faild)
            {
                return null;
            }
            for (int i = 0; i < commentDbResult.OutElements.Count; i+=4)
            {
                Comment comment = new Comment()
                {
                    Id = Convert.ToInt32(commentDbResult.OutElements.ElementAt(i)),
                    Context = commentDbResult.OutElements.ElementAt(i + 1).ToString(),
                    Customer = new User()
                    {
                        UserId = Convert.ToInt32(commentDbResult.OutElements.ElementAt(i + 2))
                    },
                };
                model.Comments.Add(comment);
            }
            return model;
        }

        public bool AddBookComment(string context, int userId, int bookId)
        {
            var dbResult = this.bookReposetory.AddBookComment(context, userId, bookId);
            return dbResult.Result == DbResult.Successed;
        }
    }
}
