using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public List<Book> GetBookByAuthor(string authorName);
        public List<Book> GetBookByName(string bookName);
        public List<Book> GetBookByGenere(string genereName);
    }
}
