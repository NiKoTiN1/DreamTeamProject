using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Services.Interfaces
{
    public interface IAccountService
    {
        public User GetUser(int userId);
        public string Login(string surname, string password);
        public string Registration(string surname, string password);
    }
}
