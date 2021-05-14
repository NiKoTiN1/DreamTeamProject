
using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Repositories
{
    public class AccountReposetory: IAccountReposetory
    {
        public AccountReposetory(IBaseReposetory baseReposetory)
        {
            this.baseReposetory = baseReposetory;
        }

        private readonly IBaseReposetory baseReposetory;

        public DbOutput Registration(string surname, string password)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_surname", OracleDbType.Varchar2, surname);
            var arg2 = new Tuple<string, OracleDbType, object>("p_password", OracleDbType.Varchar2, password);

            return this.baseReposetory.RunDbRequest("post_register_user", args: new Tuple<string, OracleDbType, object>[] { arg1, arg2 });
        }

        public DbOutput Login(string email, string password)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_email", OracleDbType.Varchar2, email);
            var arg2 = new Tuple<string, OracleDbType, object>("p_password", OracleDbType.Varchar2, password);
            var returnValArg = new Tuple<string, OracleDbType>("out_user_id", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_log_in", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1, arg2 }, returnValArg);
        }

        public DbOutput GetUser(int userId)
        {
            var arg = new Tuple<string, OracleDbType, object>("p_password", OracleDbType.Decimal, userId);
            var returnValArg = new Tuple<string, OracleDbType>("out_user", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_user", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg }, returnValArg);
        }
    }
}
