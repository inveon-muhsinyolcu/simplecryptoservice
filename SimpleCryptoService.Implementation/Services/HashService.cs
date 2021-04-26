using SimpleCryptoService.Implementation.Interfaces;
using SimpleCryptoService.Implementation.Models;
using System;

namespace SimpleCryptoService.Implementation.Services
{
    public class HashService : ISimpleCryptoService
    {
        private readonly ICryptoService _cryptoService;

        public HashService(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public bool CheckPbkdf2Format(PasswordModel model)
        {
            var hashedPassword = _cryptoService.Compute(model.Password, model.SaltKey);

            return _cryptoService.Compare(hashedPassword, model.HashedPassword);
        }

        public string HashStringToPbkdf2Format(PasswordModel model)
        {
            var crypto = _cryptoService.Compute(model.Password, model.SaltKey);
            return crypto;
        }
    }
}
