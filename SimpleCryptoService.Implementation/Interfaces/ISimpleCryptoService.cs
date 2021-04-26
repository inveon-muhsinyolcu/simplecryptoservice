using SimpleCryptoService.Implementation.Models;

namespace SimpleCryptoService.Implementation.Interfaces
{
    public interface ISimpleCryptoService
    {
        string HashStringToPbkdf2Format(PasswordModel model);
        bool CheckPbkdf2Format(PasswordModel model);
    }
}
