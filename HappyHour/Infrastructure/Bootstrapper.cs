using System;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;

namespace HappyHour.Infrastructure
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            new [] {"App", "Assets", "Scripts"}.ForEach(
                directory => nancyConventions.StaticContentsConventions.AddDirectory(directory));
            
            nancyConventions.StaticContentsConventions.AddFile("/", "/index.html");

            base.ConfigureConventions(nancyConventions);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(CreateDocumentStore());
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register(CreateDocumentSession(container));
        }

        private IDocumentStore CreateDocumentStore()
        {
            var store = 
                new DocumentStore
                {
                    Url = "http://localhost:8080", 
                    DefaultDatabase = "HappyHour"
                };
            store.Initialize();
            return store;
        }

        private IDocumentSession CreateDocumentSession(TinyIoCContainer container)
        {
            return container.Resolve<IDocumentStore>().OpenSession();
        }
    }
}
