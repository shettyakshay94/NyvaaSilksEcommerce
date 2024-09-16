namespace NyvaaSilksEcommerce.Models
{
    public class SignupModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; } // Plain text password sent by the client
    }

}
