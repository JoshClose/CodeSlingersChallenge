using System;
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
        }

        public static string ServiceHostUrl { get; private set; }

        public static string FacebookAccessToken { get; set; }
    }
}
