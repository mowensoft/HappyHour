using System.Linq;
using HappyHour.Infrastructure;
using HappyHour.Models;
using Raven.Client;

namespace HappyHour.Queries
{
    public static class GetUpcomingBallotQuery
    {
        public static Ballot GetUpcomingBallot(this IDocumentSession session)
        {
            var now = SystemTime.Now().Date;
// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
            return session.Query<Ballot>().Where(x => x.EventDate >= now).FirstOrDefault();
// ReSharper restore ReplaceWithSingleCallToFirstOrDefault
        }
    }
}
