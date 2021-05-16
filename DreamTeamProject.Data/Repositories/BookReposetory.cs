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
    }
}
