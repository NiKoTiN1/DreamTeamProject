using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamTeamProject.Services.Services
{
    public class AccountService : IAccountService
    {
        public AccountService(IAccountReposetory accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        private readonly IAccountReposetory accountRepository;

        public string Login(string email, string password)
        {
            DbOutput loginResult = this.accountRepository.Login(email, password);
            if (loginResult.Result == DbResult.Faild)
            {
                return loginResult.ErrorMessage;
            }
            if (loginResult.OutElements.Count == 0)
            {
                return "Some error!";
            }
            return loginResult.OutElements.SingleOrDefault(element => true).ToString();
        }

        public User GetUser(int userId)
        {
            DbOutput dbOut = this.accountRepository.GetUser(userId);
            if (dbOut.Result == DbResult.Faild)
            {
                Console.WriteLine(dbOut.ErrorMessage);
                return null;
            }
            var user = new User()
            {
                // code here
            };
            return user;
        }

        public string Registration(string surname, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty";
            }
            if (password.Length < 8)
            {
                return "Password length cannot be less then 8";
            }
            DbOutput registerResult = this.accountRepository.Registration(surname, password);
            if (registerResult.Result == DbResult.Faild)
            {
                return registerResult.ErrorMessage = registerResult.ErrorMessage.Substring(0, 1).ToUpper() + registerResult.ErrorMessage.Substring(1, registerResult.ErrorMessage.Length - 1).ToLower();
            }
            return null;
        }
    }
}
