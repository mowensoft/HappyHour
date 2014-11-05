using HappyHour.Models;
using Nancy;
using Raven.Client;

namespace HappyHour.Modules
{
    public class UsersModule : NancyModule
    {
        private readonly IDocumentSession documentSession;

        public UsersModule(IDocumentSession documentSession) : base("users")
        {
            this.documentSession = documentSession;

            Get["/"] = parameters => this.documentSession.Query<User>();

            After += ctx => this.documentSession.SaveChanges();
        }
    }
}
