using System.Reflection;

namespace Goo.src
{
    public class Default
    {
        private readonly PropertyInfo propertyInfo;

        public Default(PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
        }

        public object Value()
        {
            if (propertyInfo.PropertyType.Equals(typeof(string)))
                return propertyInfo.Name;
            return null;
        }
    }
}