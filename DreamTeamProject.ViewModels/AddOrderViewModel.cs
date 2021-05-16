using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.ViewModels
{
    public class AddOrderViewModel
    {
        public int BookId { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
    }
}
