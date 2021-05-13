using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int NumberOfPages { get; set; }
        public string Name { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
    }
}
