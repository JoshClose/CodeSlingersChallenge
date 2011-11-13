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
using CodeSlingers.WP7.App.Proxies;
using CodeSlingers.WP7.App.Ui;
using Microsoft.Phone.Controls;

namespace CodeSlingers.WP7.App.Views
{
	public partial class Home : ViewBase
	{
		private readonly ObservableCollection<BusinessModel> businesses = new ObservableCollection<BusinessModel>();
		private bool isLoading;
        private readonly ObservableCollection<WineModel> winesByUser = new ObservableCollection<WineModel>();
 
		public ObservableCollection<BusinessModel> Businesses
		{
			get { return businesses; }
		}

        public ObservableCollection<WineModel> WinesByUser
        {
            get { return winesByUser; }
        }

		public bool IsLoading
		{
			get { return isLoading; }
			set
			{
				isLoading = value;
				RaisePropertyChanged( () => IsLoading );
			}
		}

		public Home()
		{
			InitializeComponent();
			DataContext = this;
		}

		protected override void OnNavigatedTo( System.Windows.Navigation.NavigationEventArgs e )
		{
			string panoramaItemString;
			if( NavigationContext.QueryString.TryGetValue( "panoramaItem", out panoramaItemString ) )
			{
				var panoramaItem = (PanoramaItems)Enum.Parse( typeof( PanoramaItems ), panoramaItemString, true );

				panorama.DefaultItem = panorama.Items[(int)panoramaItem];
				switch( panoramaItem )
				{
					case PanoramaItems.MyWines:
                        LoadByUser();
						break;
					case PanoramaItems.Nearby:
						LoadBusinesses();
						break;
				}
			}
		}

		private void PanoramaSelectionChanged( object sender, SelectionChangedEventArgs e )
		{
		}

		private void NearbyGotFocus( object sender, RoutedEventArgs e )
		{
			if( businesses.Count == 0 )
			{
				LoadBusinesses();
			}
		}

		private void MyWinesGotFocus( object sender, RoutedEventArgs e )
		{
            if (winesByUser.Count == 0)
            {
                LoadByUser();
            }
		}

		private void LoadBusinesses()
		{
			IsLoading = true;
			var locationProxy = new LocationProxy();
			locationProxy.GetNearbyBusinesses( 44.862253m, -93.346592m, callback => SmartDispatcher.BeginInvoke( () =>
			{
				Businesses.Clear();
				foreach( var business in callback )
				{
					Businesses.Add( business );
				}
				IsLoading = false;
				RaisePropertyChanged( () => Businesses );
			} ) );
		}

        private void LoadByUser()
        {
            IsLoading = true;
            var userProxy = new UserProxy();
            userProxy.GetWinesByUser(Globals.FacebookAccessToken, (wines) => SmartDispatcher.BeginInvoke( () =>
                {
                    winesByUser.Clear();
                    foreach (var wine in wines)
                    {
                        winesByUser.Add(wine);
                    }
                    IsLoading = false;
                    RaisePropertyChanged(() => WinesByUser);
                }));
        }

		private void NearbyLocationItemClick( object sender, RoutedEventArgs e )
		{
			var business = ( (FrameworkElement)sender ).DataContext as BusinessModel;
			if( business == null )
			{
				return;
			}

			var uri = new Uri( string.Format( "{0}?businessId={1}&businessName={2}", ViewPaths.Business, business.Id, business.Name ), UriKind.RelativeOrAbsolute );
			NavigationService.Navigate( uri );
		}

        private void WineItemClick(object sender, RoutedEventArgs e)
        {
            var wine = ((FrameworkElement)sender).DataContext as WineModel;
            if (wine == null)
            {
                return;
            }
            var uri = new Uri(string.Format("{0}?wineId={1}", ViewPaths.WineDetail, wine.Id), UriKind.RelativeOrAbsolute);
            NavigationService.Navigate(uri);
        }
	}
}