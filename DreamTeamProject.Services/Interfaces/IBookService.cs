using DreamTeamProject.Data.Models;
using DreamTeamProject.ViewModels;
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
        public bool AddBook(Book book);
        public bool AddGenere(string genereName);
        public bool AddPubHouse(string name);
        public GetBookViewModel GetBook(int bookId);
        public bool AddBookComment(string context, int userId, int bookId);
    }
}
