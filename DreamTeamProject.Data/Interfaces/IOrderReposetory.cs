using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Interfaces
{
    public interface IOrderReposetory
    {
        public DbOutput AddOrder(int bookId, string address, string paymentMethod, int customerId);
        public DbOutput GetAllOrders();
        public DbOutput RejectOrder(int orderId);
        public DbOutput AcceptOrder(int orderId);
    }
}
