using CodeSlingers.Web.Models;
using System.Windows.Media.Imaging;

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
                    PhotoPath = new BitmapImage(new System.Uri( Globals.ServiceHostUrl + "/content/images/wines/" + wine.PhotoPath)),
                    Type = wine.Type,
                    Varietal = wine.Varietal,
                    Vineyard = wine.Vineyard,
                    Year = wine.Year,
                    Comments = wine.Comments,
                    Pairing = wine.Pairing,
                    PriceRange = wine.PriceRange,
                    CreateDate = wine.CreateDate
                };

                model.BusinessOwner = Mapper.Map(wine.BusinessOwner);
            }

            return model;
        }

        public static Wine Map(WineModel wineModel)
        {
            Wine wine = null;

            if (wineModel != null)
            {
                wine = new Wine
                {
                    Id = 0,
                    Country = wineModel.Country,
                    Name = wineModel.Name,
                    //hotoPath = wineModel.PhotoPath,
                    Type = wineModel.Type,
                    Varietal = wineModel.Varietal,
                    Vineyard = wineModel.Vineyard,
                    Year = wineModel.Year,
                    Comments = wineModel.Comments,
                    Pairing = wineModel.Pairing,
                    PriceRange = wineModel.PriceRange,
                };

                wine.BusinessOwner = new Business { Id = wineModel.BusinessOwner.Id };
            }

            return wine;
        }
	}
}
