using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Order> GetAllOrders()
        {
            var dbResult = this.orderReposetory.GetAllOrders();
            if(dbResult.Result == DbResult.Faild)
            {
                return null;
            }
            List<Order> orders = new List<Order>();
            for (int i = 0; i < dbResult.OutElements.Count; i+=7)
            {
                var order = new Order()
                {
                    Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i)),
                    Address = dbResult.OutElements.ElementAt(i + 1).ToString(),
                    FinishPrice = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 2)),
                    PaymentMethod = dbResult.OutElements.ElementAt(i + 3).ToString(),
                    DateOfDelivery = Convert.ToDateTime(dbResult.OutElements.ElementAt(i + 4)),
                    Customer = new User()
                    {
                        UserId = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 5))
                    },
                    Book = new Book()
                    {
                        Id = Convert.ToInt32(dbResult.OutElements.ElementAt(i + 6))
                    }
                };
                orders.Add(order);
            }
            return orders;
        }

        public bool RejectOrder(int orderId)
        {
            var dbResult = this.orderReposetory.RejectOrder(orderId);
            return dbResult.Result == DbResult.Successed;
        }

        public bool AcceptOrder(int orderId)
        {
            var dbResult = this.orderReposetory.AcceptOrder(orderId);
            return dbResult.Result == DbResult.Successed;
        }
    }
}
