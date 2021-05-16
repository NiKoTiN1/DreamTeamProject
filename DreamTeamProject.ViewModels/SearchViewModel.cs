using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.ViewModels
{
    public class SearchViewModel
    {
        public List<Book> SearchedByAuthor { get; set; }
        public List<Book> SearchedByBookName { get; set; }
        public List<Book> SearchedByGenere { get; set; }
    }
}
