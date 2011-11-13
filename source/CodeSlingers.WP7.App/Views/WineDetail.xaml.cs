using System;
using System.Collections.Generic;
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
	public partial class WineDetail : ViewBase
	{
		private WineModel wineModel;
		private bool isLoading;

		public WineModel WineModel
		{
			get { return wineModel; }
			set
			{
				wineModel = value;
				RaisePropertyChanged( () => WineModel );
			}
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

		public WineDetail()
		{
			InitializeComponent();
			DataContext = this;
		}

		protected override void OnNavigatedTo( System.Windows.Navigation.NavigationEventArgs e )
		{
			string wineId;
			if( NavigationContext.QueryString.TryGetValue( "wineId", out wineId ) )
			{
				LoadWine( wineId );
			}
		}

		private void LoadWine( string wineId )
		{
			IsLoading = true;
			var wineProxy = new WineProxy();
			wineProxy.GetWineDetail( wineId, callback => SmartDispatcher.BeginInvoke( () =>
			{
				IsLoading = false;
				WineModel = callback;
			} ) );
		}
	}
}