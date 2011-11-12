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
		}

		private void FindWinesClick( object sender, RoutedEventArgs e )
		{
			var uri = new Uri( ViewPaths.Home, UriKind.RelativeOrAbsolute );
			NavigationService.Navigate( uri );
		}
	}
}