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
using Microsoft.Phone.Controls;

namespace CodeSlingers.WP7.App.Views
{
	public partial class Home : PhoneApplicationPage
	{
		public Home()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo( System.Windows.Navigation.NavigationEventArgs e )
		{
			string panoramaItemString;
			if( NavigationContext.QueryString.TryGetValue( "panoramaItem", out panoramaItemString ) )
			{
				var panoramaItem = (PanoramaItems)Enum.Parse( typeof( PanoramaItems ), panoramaItemString, true );

				panorama.DefaultItem = panorama.Items[(int)panoramaItem];
			}
		}
	}
}