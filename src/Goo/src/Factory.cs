using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Goo.src
{
    public class Factory<T>
    {
        readonly Dictionary<string,IFactoryValue> factoryValues=new Dictionary<string, IFactoryValue>();

        public Association<T> Associate<TR>(Expression<Func<T, TR>> keyExpression)
        {
            Association<T> association = new Association<T>(this,PropertyName(keyExpression));
            AddToFactoryValues(keyExpression,association);
            return association;
        }

        public Factory<T> HasValue<TR>(Expression<Func<T, TR>> keyExpression, IFactorySequence sequence)
        {
            AddToFactoryValues(keyExpression,sequence);
            return this;
        }

        public Factory<T> HasValue<TR>(Expression<Func<T, TR>> keyExpression, TR value)
        {
            AddToFactoryValues(keyExpression, new HasValue(value));
            return this;
        }

        public Factory<T> HasKey<TR>(Expression<Func<T, TR>> keyExpression)
        {
            AddToFactoryValues(keyExpression,new HasKey<T,TR>(keyExpression));
            return this;
        }

        private static string PropertyName<TR>(Expression<Func<T, TR>> keyExpression)
        {
            MemberExpression body = (MemberExpression)keyExpression.Body;
            var propertyName = body.Member.Name;
            return propertyName;
        }

        private void AddToFactoryValues<TR>(Expression<Func<T, TR>> keyExpression, IFactoryValue factoryValue)
        {
            string propertyName = PropertyName(keyExpression);

            if (factoryValues.ContainsKey(propertyName))
            {
                factoryValues[propertyName] = factoryValue;
            }
            else
            {
                factoryValues.Add(propertyName, factoryValue);
            }
        }

        public T Create()
        {
            return new Creator<T>(factoryValues).Create(this);
        }
    }
}