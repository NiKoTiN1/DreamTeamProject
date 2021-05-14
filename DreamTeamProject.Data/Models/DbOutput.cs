using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Models
{
    public class DbOutput
    {
        public ICollection<object> OutElements { get; set; }
        public string ErrorMessage { get; set; }
        public DbResult Result { get; set; }
    }
}
