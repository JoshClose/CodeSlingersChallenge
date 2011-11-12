namespace CodeSlingers.Web.Models
{
    public class Business
    {
        public int Id { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Category { get; set; }

        public string PhoneNumber { get; set; }
    }
}