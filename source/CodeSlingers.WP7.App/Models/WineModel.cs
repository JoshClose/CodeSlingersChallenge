using CodeSlingers.Web.Models;
using System;

namespace CodeSlingers.WP7.App.Models
{
    public class WineModel : ModelBase
    {
    	private int id;
    	private string name;
    	private string varietal;
    	private int year;
    	private string photoPath;
    	private string vineyard;
    	private WineType type;
    	private string country;
    	private string comments;
    	private string pairing;
    	private string priceRange;
    	private BusinessModel businessOwner;
    	private DateTime createDate;
    	private byte[] photo;

    	public int Id
    	{
			get { return id; }
			set
			{
				id = value;
				RaisePropertyChanged( () => Id );
			}
    	}

    	public string Name
    	{
			get { return name; }
			set
			{
				name = value;
				RaisePropertyChanged( () => Name );
			}
    	}

    	public string Varietal
    	{
			get { return varietal; }
			set
			{
				varietal = value;
				RaisePropertyChanged( () => Varietal );
			}
    	}

    	public int Year
    	{
			get { return year; }
			set
			{
				year = value;
				RaisePropertyChanged( () => Year );
			}
		}

    	public string PhotoPath
    	{
			get { return photoPath; }
			set
			{
				photoPath = value;
				RaisePropertyChanged( () => PhotoPath );
			}
    	}

    	public string Vineyard
    	{
			get { return vineyard; }
			set
			{
				vineyard = value;
				RaisePropertyChanged( () => Vineyard );
			}
    	}

    	public WineType Type
    	{
			get { return type; }
			set
			{
				type = value;
				RaisePropertyChanged( () => Type );
			}
    	}

    	public string Country
    	{
			get { return country; }
			set
			{
				country = value;
				RaisePropertyChanged( () => Country );
			}
    	}

    	public string Comments
    	{
			get { return comments; }
			set
			{
				comments = value;
				RaisePropertyChanged( () => Comments );
			}
    	}

    	public string Pairing
    	{
			get { return pairing; }
			set
			{
				pairing = value;
				RaisePropertyChanged( () => Pairing );
			}
    	}

    	public string PriceRange
    	{
			get { return priceRange; }
			set
			{
				priceRange = value;
				RaisePropertyChanged( () => PriceRange );
			}
    	}

    	public BusinessModel BusinessOwner
    	{
			get { return businessOwner; }
			set
			{
				businessOwner = value;
				RaisePropertyChanged( () => BusinessOwner );
			}
    	}

    	public DateTime CreateDate
    	{
			get { return createDate; }
			set
			{
				createDate = value;
				RaisePropertyChanged( () => CreateDate );
			}
    	}

    	public byte[] Photo
    	{
			get { return photo; }
			set
			{
				photo = value;
				RaisePropertyChanged( () => Photo );
			}
    	}
    }
}
