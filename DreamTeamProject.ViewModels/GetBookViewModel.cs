using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.ViewModels
{
    public class GetBookViewModel
    {
        public Book Book { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
