using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Services.Interfaces
{
    public interface IOrderService
    {
        public bool AddOrder(int bookId, string address, string paymentMethod, int customerId);
    }
}
