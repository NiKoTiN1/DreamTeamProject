using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Repositories
{
    public class OrderReposetory: IOrderReposetory
    {
        public OrderReposetory(IBaseReposetory baseReposetory)
        {
            this.baseReposetory = baseReposetory;
        }

        private readonly IBaseReposetory baseReposetory;

        public DbOutput AddOrder(int bookId, string address, string paymentMethod, int customerId)
        {
            var arg1 = new Tuple<string, OracleDbType, object>("id_book", OracleDbType.Decimal, bookId);
            var arg2 = new Tuple<string, OracleDbType, object>("address_order", OracleDbType.Varchar2, address);
            var arg3 = new Tuple<string, OracleDbType, object>("pay_method", OracleDbType.Varchar2, paymentMethod);
            var arg4 = new Tuple<string, OracleDbType, object>("id_u", OracleDbType.Varchar2, customerId);
            return this.baseReposetory.RunDbRequest("create_book_order", mustRespond: false, args: new Tuple<string, OracleDbType, object>[] { arg1, arg2, arg3, arg4 });
        }
    }
}
