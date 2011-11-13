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

namespace CodeSlingers.WP7.App.Views
{
	public partial class Business : ViewBase
	{
		private readonly ObservableCollection<WineModel> wines = new ObservableCollection<WineModel>();
		private BusinessModel businessModel = new BusinessModel();
		private bool isLoading;

		public ObservableCollection<WineModel> Wines
		{
			get { return wines; }
		}

		public BusinessModel BusinessModel
		{
			get { return businessModel; }
			set
			{
				businessModel = value;
				RaisePropertyChanged( () => BusinessModel );
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

		public Business()
		{
			InitializeComponent();
			DataContext = this;
		}

		protected override void OnNavigatedTo( System.Windows.Navigation.NavigationEventArgs e )
		{
			string businessId;
			if( NavigationContext.QueryString.TryGetValue( "businessId", out businessId ) )
			{
				businessModel.Id = businessId;
				LoadBusiness( businessId );
			}
			string businessName;
			if( NavigationContext.QueryString.TryGetValue( "businessName", out businessName ) )
			{
				businessModel.Name = businessName;
			}
		}

		private void LoadBusiness( string businessId )
		{
			IsLoading = true;
			var wineProxy = new WineProxy();
			wineProxy.GetWinesByBusiness( businessId, callback => SmartDispatcher.BeginInvoke( () =>
			{
				foreach( var wine in callback )
				{
					wines.Add( wine );
				}
				IsLoading = false;
				RaisePropertyChanged( () => Wines );
			} ) );
		}
	}
}