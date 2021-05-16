using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;

namespace DreamTeamProject.Data.Repositories
{
    public class BookReposetory: IBookReposetory
    {
        public BookReposetory(IBaseReposetory baseReposetory)
        {
            this.baseReposetory = baseReposetory;
        }

        private readonly IBaseReposetory baseReposetory;

        public DbOutput GetAllBooks()
        {
            var returnValArg = new Tuple<string, OracleDbType>("out_allbooks", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_all_books", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { }, returnValArg);
        }

        public DbOutput GetBookByAuthor(string authorSurname)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("s_author", OracleDbType.Varchar2, authorSurname);
            var returnValArg = new Tuple<string, OracleDbType>("out_author", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_book_by_author", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput GetBookByName(string bookName)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("s_book_name", OracleDbType.Varchar2, bookName);
            var returnValArg = new Tuple<string, OracleDbType>("out_book", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_book_by_name", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput GetBookByGenere(string genereName)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("s_genre", OracleDbType.Varchar2, genereName);
            var returnValArg = new Tuple<string, OracleDbType>("out_genre", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_book_by_genre", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput AddBook(Book book)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("name_book", OracleDbType.Varchar2, book.Name);
            var arg2 = new Tuple<string, OracleDbType, object>("num_of_pages", OracleDbType.Decimal, book.NumberOfPages);
            var arg3 = new Tuple<string, OracleDbType, object>("pric", OracleDbType.Decimal, book.Price);
            var arg4 = new Tuple<string, OracleDbType, object>("b_count", OracleDbType.Decimal, book.BookCount);
            var arg5 = new Tuple<string, OracleDbType, object>("id_ph", OracleDbType.Decimal, book.PublishingHouse.Id);
            var arg6 = new Tuple<string, OracleDbType, object>("id_g", OracleDbType.Decimal, book.Genere.Id);
            var arg7 = new Tuple<string, OracleDbType, object>("id_a", OracleDbType.Decimal, book.Author.UserId);
            return this.baseReposetory.RunDbRequest("Insert_Book", mustRespond: false, args: new Tuple<string, OracleDbType, object>[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        }

        public DbOutput AddGenere(string genereName)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("name_g", OracleDbType.Varchar2, genereName);
            return this.baseReposetory.RunDbRequest("Insert_Genre", mustRespond: false, args: new Tuple<string, OracleDbType, object>[] { arg1 });
        }

        public DbOutput AddPubHouse(string name)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("name_ph", OracleDbType.Varchar2, name);
            return this.baseReposetory.RunDbRequest("Insert_PubHouse", mustRespond: false, args: new Tuple<string, OracleDbType, object>[] { arg1 });
        }

        public DbOutput GetBook(int bookId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("s_book_id", OracleDbType.Decimal, bookId);
            var returnValArg = new Tuple<string, OracleDbType>("out_book_id", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_book_by_id", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput GetBookComments(int bookId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("b_id", OracleDbType.Decimal, bookId);
            var returnValArg = new Tuple<string, OracleDbType>("out_allcom", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_comments_of_book", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput AddBookComment(string context, int userId, int bookId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("c_context", OracleDbType.Varchar2, context);
            var arg2 = new Tuple<string, OracleDbType, object>("u_id", OracleDbType.Decimal, userId);
            var arg3 = new Tuple<string, OracleDbType, object>("b_id", OracleDbType.Decimal, bookId);
            return this.baseReposetory.RunDbRequest("get_comments_of_book", mustRespond: false, args: new Tuple<string, OracleDbType, object>[] { arg1, arg2, arg3 });
        }
    }
}
