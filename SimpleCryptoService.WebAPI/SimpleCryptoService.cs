using Nancy;
using Nancy.ModelBinding;
using SimpleCryptoService.Implementation.Interfaces;
using SimpleCryptoService.Implementation.Models;

namespace SimpleCryptoService.WebAPI
{
    public class SimpleCryptoService : NancyModule
    {
        public SimpleCryptoService(ISimpleCryptoService simpleCryptoService)
            : base("api")
        {
            Get("/healthcheck", _ =>
            {
                return HttpStatusCode.OK;
            });

            Get("get-pbkdf2sha256-format", _ =>
            {
                var model = this.Bind<PasswordModel>();
                var result = simpleCryptoService.HashStringToPbkdf2Format(model);

                return result;
            });

            Get("check-pbkdf2sha256-format", _ =>
            {
                var model = this.Bind<PasswordModel>();
                var result = simpleCryptoService.CheckPbkdf2Format(model);

                return result;
            });
        }
    }
}