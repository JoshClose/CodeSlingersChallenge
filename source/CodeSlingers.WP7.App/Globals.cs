using System;
using System.Device.Location;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CodeSlingers.WP7.App
{
    public static class Globals
    {
        static Globals()
        {
            ServiceHostUrl = "http://localhost/CodeSlingers.Web";
        	var watcher = new GeoCoordinateWatcher( GeoPositionAccuracy.Default );
			watcher.PositionChanged += WatcherPositionChanged;
			watcher.StatusChanged += WatcherStatusChanged;
        	watcher.Start();
        }

		static void WatcherPositionChanged( object sender, GeoPositionChangedEventArgs<GeoCoordinate> e )
		{
		}

		static void WatcherStatusChanged( object sender, GeoPositionStatusChangedEventArgs e )
		{
			Debug.WriteLine( "GeoPosition Status Changed: {0}", e.Status );
		}

        public static string ServiceHostUrl { get; private set; }
    }
}
