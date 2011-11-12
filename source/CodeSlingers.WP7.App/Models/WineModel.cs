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
using CodeSlingers.Web.Models;

namespace CodeSlingers.WP7.App.Models
{
    public class WineModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Varietal { get; set; }

        public int Year { get; set; }

        public string PhotoPath { get; set; }

        public string Vineyard { get; set; }

        public WineType Type { get; set; }

        public string Country { get; set; }

        public string Comments { get; set; }

        public string Pairing { get; set; }

        public string PriceRange { get; set; }

        public BusinessModel BusinessOwner { get; set; }
    }
}
