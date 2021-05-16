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

        public bool AddOrder(Order order)
        {
            var dbResult = this.orderReposetory.AddOrder(order);
            return dbResult.Result == DbResult.Successed;
        }

    }
}
