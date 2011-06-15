using System;
using System.Collections.Generic;
using System.Reflection;

namespace Goo.src
{
    public class Creator<T>
    {
        private readonly Dictionary<string, IFactoryValue> factoryValues;

        public Creator(Dictionary<string, IFactoryValue> factoryValues)
        {
            this.factoryValues = factoryValues;
        }

        public T Create(object factoryConfiguration)
        {
            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties())
            {
                object value = new Default(propertyInfo).Value();
                if(factoryValues.ContainsKey(propertyInfo.Name))
                {
                    IFactoryValue factoryValue = factoryValues[propertyInfo.Name];
                    value = factoryValue.Value();
                }
                
                Type type = instance.GetType();
                try
                {
                    type.GetProperty(propertyInfo.Name).SetValue(instance, value, null);
                }
                catch
                {
                    throw new ApplicationException(
                        string.Format(
                            "\nException Was throw in configuration {0} for class {1},\n Was Not able to set value {2} to property {3}",
                            factoryConfiguration.GetType().Name, typeof (T).Name, value, propertyInfo.Name));
                }
            }
            return instance;
        }
    }
}