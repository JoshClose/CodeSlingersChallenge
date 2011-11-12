namespace CodeSlingers.Web.Models
{
    public class Business
    {
        public string Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int Distance { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Category { get; set; }

        public string PhoneNumber { get; set; }

        public string FormattedPhoneNumber { get; set; }
    }
}