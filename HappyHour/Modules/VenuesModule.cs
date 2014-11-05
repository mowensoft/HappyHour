using System;
using HappyHour.Models;
using Nancy;
using Raven.Client;

namespace HappyHour.Modules
{
    public class VenuesModule : NancyModule
    {
        private readonly IDocumentSession documentSession;

        public VenuesModule(IDocumentSession documentSession)
            : base("venues")
        {
            this.documentSession = documentSession;

            Get["/"] = _ => this.documentSession.Query<Venue>();
            Get["/explore"] = Explore;
            
            After += ctx => this.documentSession.SaveChanges();
        }

        public Func<dynamic, dynamic> Explore(dynamic parameters)
        {
            throw new NotImplementedException();
        }
    }
}
