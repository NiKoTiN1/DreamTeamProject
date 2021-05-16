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

        public Customer GetUser(int userId)
        {
            DbOutput dbOut = this.accountRepository.GetUser(userId);
            if (dbOut.Result == DbResult.Faild)
            {
                Console.WriteLine(dbOut.ErrorMessage);
                return null;
            }
            var user = new Customer()
            {
                UserId = Convert.ToInt32(dbOut.OutElements.ElementAt(0)),
                Email = dbOut.OutElements.ElementAt(1).ToString(),
                SurName = dbOut.OutElements.ElementAt(2).ToString(),
                Phone = dbOut.OutElements.ElementAt(3).ToString(),
                UserRole = new Role()
                {
                    Id = Convert.ToInt32(dbOut.OutElements.ElementAt(4)),
                    Name = dbOut.OutElements.ElementAt(5).ToString()
                }
            };
            return user;
        }

        public string Registration(Customer customer, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty";
            }
            if (password.Length < 8)
            {
                return "Password length cannot be less then 8";
            }
            DbOutput registerResult = this.accountRepository.Registration(customer, password);
            if (registerResult.Result == DbResult.Faild)
            {
                return registerResult.ErrorMessage = registerResult.ErrorMessage.Substring(0, 1).ToUpper() + registerResult.ErrorMessage.Substring(1, registerResult.ErrorMessage.Length - 1).ToLower();
            }
            return null;
        }

        public Customer ChangeRole(int userId, int roleId)
        {
            DbOutput dbOut = this.accountRepository.ChangeRole(userId, roleId);
            if (dbOut.Result == DbResult.Faild)
            {
                Console.WriteLine(dbOut.ErrorMessage);
                return null;
            }
            var user = this.GetUser(userId);
            return user;
        }

        public List<Customer> GetAllUsers()
        {
            DbOutput dbOut = this.accountRepository.GetAllUsers();
            if (dbOut.Result == DbResult.Faild)
            {
                Console.WriteLine(dbOut.ErrorMessage);
                return null;
            }

            List<Customer> users = new List<Customer>();
            for (int i = 0; i < dbOut.OutElements.Count; i += 7)
            {
                var user = new Customer()
                {
                    UserId = Convert.ToInt32(dbOut.OutElements.ElementAt(i)),
                    Email = dbOut.OutElements.ElementAt(i + 1).ToString(),
                    SurName = dbOut.OutElements.ElementAt(i + 2).ToString(),
                    Name = dbOut.OutElements.ElementAt(i + 3).ToString(),
                    Phone = dbOut.OutElements.ElementAt(i + 4).ToString(),
                    UserRole = new Role()
                    {
                        Id = Convert.ToInt32(dbOut.OutElements.ElementAt(i + 5)),
                        Name = dbOut.OutElements.ElementAt(i + 6).ToString()
                    }
                };
                users.Add(user);
            }

            return users;
        }
    }
}
