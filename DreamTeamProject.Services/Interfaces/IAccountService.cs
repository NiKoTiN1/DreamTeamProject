using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Services.Interfaces
{
    public interface IAccountService
    {
        public Customer GetUser(int userId);
        public string Login(string surname, string password);
        public string Registration(string nickname, string email, string password);
        public Customer ChangeRole(int userId, int roleId);
        public List<Customer> GetAllUsers();
        public bool IsAdmin(string userId);
    }
}
