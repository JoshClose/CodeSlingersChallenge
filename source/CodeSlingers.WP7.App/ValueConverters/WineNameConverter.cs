using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using CodeSlingers.WP7.App.Models;

namespace CodeSlingers.WP7.App.ValueConverters
{
	public class WineNameConverter : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			var wine = value as WineModel;
			if( wine == null )
			{
				return value;
			}
			var name = new StringBuilder();
			if( !string.IsNullOrWhiteSpace( wine.Name ) )
			{
				name.Append( wine.Name );
			}
			if( wine.Year > 0 )
			{
				if( name.Length > 0 )
				{
					name.Append( ", " );
				}
				name.Append( wine.Year );
			}
			// TODO: Price range.
			return name.ToString();
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotSupportedException();
		}
	}
}
