using DreamTeamProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
    }
}
