using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CodeSlingers.WP7.App.Models;
using CodeSlingers.Web.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;

namespace CodeSlingers.WP7.App.Views
{
	public partial class AddWine : ViewBase
	{
		private WineModel wineModel = new WineModel();
		private readonly ObservableCollection<string> wineTypes = new ObservableCollection<string>();

		public WineModel WineModel
		{
			get { return wineModel; }
			set
			{
				wineModel = value;
				RaisePropertyChanged( () => WineModel );
			}
		}

		public IEnumerable<string> WineTypes
		{
			get { return GetWineTypes(); }
		}

		public IEnumerable<string> Prices
		{
			get { return GetPriceRanges(); }
		}

		public AddWine()
		{
			InitializeComponent();
			DataContext = this;
		}

		private void AddPhotoClick( object sender, RoutedEventArgs e )
		{
			RadMessageBox.Show( new[] { "use photo from library", "take a picture", "cancel" }, "Add photo:", closedHandler: callback =>
			{
				switch( callback.ButtonIndex )
				{
					case 0:
						ChoosePhotoFromLibrary();
						break;
					case 1:
						TakePictureFromCamera();
						break;
				}
			} );
		}

		private void AddLocationClick( object sender, RoutedEventArgs e )
		{
		}

		private void ChoosePhotoFromLibrary()
		{
			var task = new PhotoChooserTask();
			task.Completed += ( sender, args ) => { };
			task.Show();
		}

		private void TakePictureFromCamera()
		{
			var task = new CameraCaptureTask();
			task.Completed += ( sender, args ) => { };
			task.Show();
		}

		private IEnumerable<string> GetWineTypes()
		{
			return new[]
			{
				"Red",
				"White",
				"Rose",
				"Dessert",
			};
		}

		private IEnumerable<string> GetPriceRanges()
		{
			return new[]
			{
				PriceRanges.UnderTwentyFive,
				PriceRanges.TwentyFiveToFifty,
				PriceRanges.FiftyToOneHundred,
				PriceRanges.OverOneHundred,
			};
		}
	}
}