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
using CodeSlingers.WP7.App.Views;
using Microsoft.Phone.Controls;

namespace CodeSlingers.WP7.App
{
	public partial class MainPage : PhoneApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void SignInFacebookClick( object sender, RoutedEventArgs e )
		{
            NavigationService.Navigate(new Uri("/FacebookLoginPage.xaml", UriKind.Relative));
		}

		private void FindWinesClick( object sender, RoutedEventArgs e )
		{
			var uri = new Uri( string.Format( "{0}?panoramaItem={1}", ViewPaths.Home, PanoramaItems.Nearby ), UriKind.RelativeOrAbsolute );
			NavigationService.Navigate( uri );
		}
	}
}