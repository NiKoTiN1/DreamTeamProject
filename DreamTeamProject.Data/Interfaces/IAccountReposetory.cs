using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Interfaces
{
    public interface IAccountReposetory
    {
        public DbOutput Registration(string surname, string password);
        public DbOutput Login(string email, string password);
        public DbOutput GetUser(int userId);
    }
}
