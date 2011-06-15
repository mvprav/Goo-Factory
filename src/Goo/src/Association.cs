using System;

namespace Goo.src
{
    public class Association<T>:IFactoryValue
    {
        private readonly Factory<T> factory;
        private readonly string propertyName;
        private Type associatesWith;

        public Association(Factory<T> factory, string propertyName)
        {
            this.factory = factory;
            this.propertyName = propertyName;
        }

        public string PropertyName
        {
            get { return propertyName; }
        }

        public object Value()
        {
                var instance = Activator.CreateInstance(associatesWith);
                var methodInfo = associatesWith.GetMethod("Create");
                return methodInfo.Invoke(instance, null);
        }

        public Factory<T> With<TA>()
        {
            associatesWith = typeof (TA);
            return factory;
        }
    }
}