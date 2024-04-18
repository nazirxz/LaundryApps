namespace LaundryApps.Models
{
    public class User
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string fullname, string email, string password)
        {
            Fullname = fullname;
            Email = email;
            Password = password;
        }

        public User()
        {
            Fullname = Fullname;
            Email = Email;
            Password = Password;
        }
    }
}
