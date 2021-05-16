using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Interfaces
{
    public interface IBookReposetory
    {
        public DbOutput GetAllBooks();
        public DbOutput GetBookByAuthor(string authorSurname);
        public DbOutput GetBookByName(string bookName);
        public DbOutput GetBookByGenere(string genereName);
        public DbOutput AddBook(Book book);
        public DbOutput AddGenere(string genereName);
        public DbOutput AddPubHouse(string name);
        public DbOutput GetBook(int bookId);
    }
}
