namespace CodeSlingers.WP7.App.Models
{
	public class BusinessModel : ModelBase
	{
		private string id;
		private decimal latitude;
		private decimal longitude;
		private string name;
		private string address;
		private string city;
		private string state;
		private string category;
		private string phoneNumber;

		public string Id
		{
			get { return id; }
			set
			{
				id = value;
				RaisePropertyChanged( () => Id );
			}
		}

		public decimal Latitude
		{
			get { return latitude; }
			set
			{
				latitude = value;
				RaisePropertyChanged( () => Latitude );
			}
		}

		public decimal Longitude
		{
			get { return longitude; }
			set
			{
				longitude = value;
				RaisePropertyChanged( () => Longitude );
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

		public string Address
		{
			get { return address; }
			set
			{
				address = value;
				RaisePropertyChanged( () => Address );
			}
		}

		public string City
		{
			get { return city; }
			set
			{
				city = value;
				RaisePropertyChanged( () => City );
			}
		}

		public string State
		{
			get { return state; }
			set
			{
				state = value;
				RaisePropertyChanged( () => State );
			}
		}

		public string Category
		{
			get { return category; }
			set
			{
				category = value;
				RaisePropertyChanged( () => Category );
			}
		}

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set
			{
				phoneNumber = value;
				RaisePropertyChanged( () => PhoneNumber );
			}
		}

		public string AddressDisplay
		{
			get { return string.Format( "{0} {1} {2}", address, city, state ); }
		}
	}
}
