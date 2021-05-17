
using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;

namespace DreamTeamProject.Data.Repositories
{
    public class AccountReposetory: IAccountReposetory
    {
        public AccountReposetory(IBaseReposetory baseReposetory)
        {
            this.baseReposetory = baseReposetory;
        }

        private readonly IBaseReposetory baseReposetory;

        public DbOutput Registration(string nickname, string email, string password)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_nickname", OracleDbType.Varchar2, nickname);
            var arg2 = new Tuple<string, OracleDbType, object>("p_email", OracleDbType.Varchar2, email);
            var arg3 = new Tuple<string, OracleDbType, object>("p_password", OracleDbType.Varchar2, password);

            return this.baseReposetory.RunDbRequest("post_register_user", args: new Tuple<string, OracleDbType, object>[] { arg1, arg2, arg3 });
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

        public DbOutput ChangeRole(int userId, int roleId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_user_id", OracleDbType.Decimal, userId);
            var arg2 = new Tuple<string, OracleDbType, object>("p_role_id", OracleDbType.Decimal, roleId);
            return this.baseReposetory.RunDbRequest("post_change_role", args: new Tuple<string, OracleDbType, object>[] { arg1, arg2 });
        }

        public DbOutput GetAllUsers()
        {
            var returnValArg = new Tuple<string, OracleDbType>("out_users", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_all_users", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { }, returnVal: returnValArg);
        }

        public DbOutput DeleteUser(int userId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_user_id", OracleDbType.Decimal, userId);
            return this.baseReposetory.RunDbRequest("post_del_user", args: new Tuple<string, OracleDbType, object>[] { arg1 });
        }
    }
}
