using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SimpleCryptoService.Implementation.Interfaces;
using SimpleCryptoService.Implementation.Services;

namespace SimpleCryptoService.WebAPI
{
    public class SimpleCryptoServiceNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            container.Register<ISimpleCryptoService, HashService>().AsSingleton();
            container.Register<ICryptoService, PBKDF2Service>().AsSingleton();
        }

    }
}