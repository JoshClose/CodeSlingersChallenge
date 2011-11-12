﻿using System;
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
using Microsoft.Phone.Controls;

namespace CodeSlingers.WP7.App.Views
{
	public partial class Home : ViewBase
	{
		private readonly ObservableCollection<BusinessModel> businesses = new ObservableCollection<BusinessModel>();
 
		public ObservableCollection<BusinessModel> Businesses
		{
			get { return businesses; }
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
		}

		private void LoadBusinesses()
		{
			businesses.Add( new BusinessModel { Name = "Bank", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "M&S Grill", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Surdyk's Liquor Store", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Haskell's Wine Shop", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Ike's Food and Cocktails", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Restaurant Alma", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Uptown Bar", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Bank 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "M&S Grill 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Surdyk's Liquor Store 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Haskell's Wine Shop 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Ike's Food and Cocktails 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Restaurant Alma 2", Address = "123 4th st", City = "apple", State = "MN" } );
			businesses.Add( new BusinessModel { Name = "Uptown Bar 2", Address = "123 4th st", City = "apple", State = "MN" } );
			RaisePropertyChanged( () => Businesses );
		}
	}
}