using Nancy;

namespace SimpleCryptoService.WebAPI
{
    public class HealthCheckService : NancyModule
    {
        public HealthCheckService()
        {
            Get("/", _ =>
            {
                return HttpStatusCode.OK;
            });
        }
    }
}