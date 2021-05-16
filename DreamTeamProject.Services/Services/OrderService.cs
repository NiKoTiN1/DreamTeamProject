using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Services.Services
{
    public class OrderService: IOrderService
    {
        public OrderService(IOrderReposetory orderReposetory)
        {
            this.orderReposetory = orderReposetory;
        }

        private readonly IOrderReposetory orderReposetory;

        public bool AddOrder(int bookId, string address, string paymentMethod, int customerId)
        {
            var dbResult = this.orderReposetory.AddOrder(bookId, address, paymentMethod, customerId);
            return dbResult.Result == DbResult.Successed;
        }

    }
}
