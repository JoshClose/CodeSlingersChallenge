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
using Microsoft.Phone.Controls;

namespace CodeSlingers.WP7.App.Views
{
	public partial class Business : ViewBase
	{
		private BusinessModel businessModel;

		public BusinessModel BusinessModel
		{
			get { return businessModel; }
			set
			{
				businessModel = value;
				RaisePropertyChanged( () => BusinessModel );
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
				LoadBusiness( businessId );
			}
		}

		private void LoadBusiness( string businessId )
		{
		}
	}
}