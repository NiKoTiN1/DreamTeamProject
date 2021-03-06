using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Interfaces
{
    public interface IAccountReposetory
    {
        public DbOutput Registration(string nickname, string email, string password);
        public DbOutput Login(string email, string password);
        public DbOutput GetUser(int userId);
        public DbOutput ChangeRole(int userId, int roleId);
        public DbOutput GetAllUsers();
        public DbOutput DeleteUser(int userId);
    }
}
