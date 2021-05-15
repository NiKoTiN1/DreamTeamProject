
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

        public DbOutput Registration(Customer customer, string password)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_surname", OracleDbType.Varchar2, customer.SurName);
            var arg2 = new Tuple<string, OracleDbType, object>("p_name", OracleDbType.Varchar2, customer.Name);
            var arg3 = new Tuple<string, OracleDbType, object>("p_mobile_phone", OracleDbType.Varchar2, customer.Phone);
            var arg4 = new Tuple<string, OracleDbType, object>("p_email", OracleDbType.Varchar2, customer.Email);
            var arg5 = new Tuple<string, OracleDbType, object>("p_password", OracleDbType.Varchar2, password);

            return this.baseReposetory.RunDbRequest("post_register_customer", args: new Tuple<string, OracleDbType, object>[] { arg1, arg2, arg3, arg4, arg5 });
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
            var arg1 = new Tuple<string, OracleDbType, object>("p_customerid", OracleDbType.Decimal, userId);
            var returnValArg = new Tuple<string, OracleDbType>("out_customer", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_customer", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { arg1 }, returnValArg);
        }

        public DbOutput ChangeRole(int userId, int roleId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_customer_id", OracleDbType.Decimal, userId);
            var arg2 = new Tuple<string, OracleDbType, object>("p_role_id", OracleDbType.Decimal, roleId);
            return this.baseReposetory.RunDbRequest("post_change_role", args: new Tuple<string, OracleDbType, object>[] { arg1, arg2 });
        }

        public DbOutput GetAllUsers()
        {
            var returnValArg = new Tuple<string, OracleDbType>("out_customers", OracleDbType.RefCursor);
            return this.baseReposetory.RunDbRequest("get_all_customers", mustRespond: true, args: new Tuple<string, OracleDbType, object>[] { }, returnVal: returnValArg);
        }

        public DbOutput DeleteUser(int userId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("p_customer_id", OracleDbType.Decimal, userId);
            return this.baseReposetory.RunDbRequest("post_del_customer", args: new Tuple<string, OracleDbType, object>[] { arg1 });
        }
    }
}
