using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Goo
{
    public class HasKey<T, TR> : IFactoryValue
    {
        private readonly Expression<Func<T, TR>> keyExpression;

        public HasKey(Expression<Func<T, TR>> keyExpression)
        {
            this.keyExpression = keyExpression;
        }

        public object Value()
        {
            T instance = Activator.CreateInstance<T>();
            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(PropertyName(keyExpression));
            return propertyInfo.GetValue(instance, null);
        }

        private static string PropertyName<TR>(Expression<Func<T, TR>> keyExpression)
        {
            MemberExpression body = (MemberExpression)keyExpression.Body;
            var propertyName = body.Member.Name;
            return propertyName;
        }
    }
}