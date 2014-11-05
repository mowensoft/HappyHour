using System;
using System.Collections.Generic;
using System.Linq;
using HappyHour.Exceptions;
using HappyHour.Infrastructure;

namespace HappyHour.Models
{
    public class Ballot
    {
        public Ballot()
        {
            BallotEntries = new List<BallotEntry>();
        }

        public string Id { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime VotingExpires { get; set; }
        public List<BallotEntry> BallotEntries { get; set; }

        public void VoteFor(string userId, string venueId)
        {
            if (SystemTime.Now() > VotingExpires)
            {
                throw new VotingNotAllowedException(string.Format("Voting expired on {0}", VotingExpires));
            }

            var ballotEntry = BallotEntries.FirstOrDefault(entry => entry.Venue.Id == venueId);
            if (ballotEntry == null)
            {
                throw new VotingException("No ballet entry exists for the given location");
            }

            if (ballotEntry.HasUserAlreadyVoted(userId))
            {
                throw new VotingNotAllowedException("The specified user has already voted on this ballot");
            }

            ballotEntry.Votes.Add(userId);
        }

        public class BallotEntry
        {
            public BallotEntry()
            {
                Votes = new List<string>();
            }

            public VenueRef Venue { get; set; }
            public List<string> Votes { get; set; }

            public bool HasUserAlreadyVoted(string userId)
            {
                return Votes.Contains(userId);
            }
        }
    }
}
