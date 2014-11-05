using System;
using System.Runtime.Serialization;

namespace HappyHour.Exceptions
{
    [Serializable]
    public class VotingException : Exception
    {
        public VotingException()
        {
        }

        public VotingException(string message)
            : base(message)
        {
        }

        public VotingException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected VotingException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
