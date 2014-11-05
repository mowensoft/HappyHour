using System;
using System.Runtime.Serialization;

namespace HappyHour.Exceptions
{
    [Serializable]
    public class VotingNotAllowedException : Exception
    {
        public VotingNotAllowedException()
        {
        }

        public VotingNotAllowedException(string message) : base(message)
        {
        }

        public VotingNotAllowedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected VotingNotAllowedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
