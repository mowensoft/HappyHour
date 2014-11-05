using System;

namespace HappyHour.Infrastructure
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
