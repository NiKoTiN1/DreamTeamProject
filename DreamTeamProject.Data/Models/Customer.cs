namespace DreamTeamProject.Data.Models
{
    public class Customer : User
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role UserRole { get; set; }
    }
}
