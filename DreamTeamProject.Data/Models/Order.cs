using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FinishPrice { get; set; }
        public string Address { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string PaymentMethod { get; set; }
        public User Seller { get; set; }
        public User Customer { get; set; }
        public Book Book { get; set; }
    }
}
