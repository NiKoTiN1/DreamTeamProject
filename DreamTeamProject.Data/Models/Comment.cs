using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Context { get; set; }
        public Book Book { get; set; }
        public User Customer { get; set; }
    }
}
