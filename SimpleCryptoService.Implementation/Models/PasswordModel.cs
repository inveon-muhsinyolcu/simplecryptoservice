namespace SimpleCryptoService.Implementation.Models
{
    public class PasswordModel
    {
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public string HashedPassword { get; set; }
    }
}
