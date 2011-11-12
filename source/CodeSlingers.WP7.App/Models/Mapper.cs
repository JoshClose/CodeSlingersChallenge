using CodeSlingers.Web.Models;

namespace CodeSlingers.WP7.App.Models
{
	public static class Mapper
	{
		// Data to model.

		public static BusinessModel Map( Business data )
		{
            BusinessModel model = null;

            if (data != null)
            {
                model = new BusinessModel
                {
                    Address = data.Address,
                    Category = data.Category,
                    City = data.City,
                    Id = data.Id,
                    Latitude = data.Latitude,
                    Longitude = data.Longitude,
                    Name = data.Name,
                    PhoneNumber = data.PhoneNumber,
                    State = data.State,
                };
            }

            return model;
		}

        public static WineModel Map(Wine wine)
        {
            WineModel model = null;

            if (wine != null)
            {
                model = new WineModel
                {
                    Id = wine.Id,
                    Country = wine.Country,
                    Name = wine.Name,
                    PhotoPath = wine.PhotoPath,
                    Type = wine.Type,
                    Varietal = wine.Varietal,
                    Vineyard = wine.Vineyard,
                    Year = wine.Year
                };
            }

            return model;
        }
	}
}
