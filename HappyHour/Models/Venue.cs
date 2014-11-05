namespace HappyHour.Models
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class VenueRef
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
