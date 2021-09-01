using AppShopping.Library.Enuns;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppShopping.Library.Converters
{
    public class EstablishmentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EstablishmentType type = (EstablishmentType)value;
            string categoria = "";

            if (type == EstablishmentType.Restaurant)
            {
                categoria = "Restaurante";
            }
            else if (type == EstablishmentType.Store)
            {
                categoria = "Loja";
            }
            else
            {
                categoria = "Insira nova categoria na classe EstablishmentType";
            }

            return categoria;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
