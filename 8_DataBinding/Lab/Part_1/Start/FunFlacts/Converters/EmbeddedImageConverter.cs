using FlagData;
using FunFlacts.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FunFlacts.Converters
{
    public class EmbeddedImageConverter : IValueConverter
    {
        /// <summary>
        /// Optional type located in the assembly we want to get the resource from - if not supplied, 
        /// the API assumes the resource is located in this assembly.
        /// </summary>
        public Type ResolvingAssemblyType { get; set; }

        /// <summary>
        /// Takes the Image URL and gets the respective ImageResource
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageUrl = (value ?? "").ToString();

            if (string.IsNullOrEmpty(imageUrl))
                return null;
            
            return ImageSource.FromResource(imageUrl, ResolvingAssemblyType?.GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // not supported
            throw new NotImplementedException();
        }
    }
}
