using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.Phone.Controls;
using Microsoft.Practices.Prism.ViewModel;

namespace CodeSlingers.WP7.App.Views
{
	public class ViewBase : PhoneApplicationPage, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged( string propertyName )
		{
			if( PropertyChanged != null )
			{
				PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
			}
		}

		public void RaisePropertyChanged<T>( Expression<Func<T>> propertyExpression )
		{
			var propertyName = PropertySupport.ExtractPropertyName( propertyExpression );
			RaisePropertyChanged( propertyName );
		}
	}
}
