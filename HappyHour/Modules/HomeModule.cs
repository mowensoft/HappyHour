using Nancy;

namespace HappyHour.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule() : base(string.Empty)
        {
            Get["/"] = parameters => Response.AsFile("index.html");
        }
    }
}
