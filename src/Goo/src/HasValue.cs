namespace Goo
{
    public class HasValue : IFactoryValue
    {
        private readonly object value;

        public HasValue(object value)
        {
            this.value = value;
        }


        public object Value()
        {
            return value;
        }
    }
}