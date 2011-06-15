namespace Goo.src
{
    public interface IFactorySequence:IFactoryValue
    {
    }

  

    public class FactorySequence : IFactorySequence
    {
        private static int count;
        private readonly string value;

        public FactorySequence(string value)
        {
            count++;
            this.value = string.Format(value, count);
        }

        public object Value()
        {
            return value;
        }

        public static int Count
        {
            get {
                return count;
            }
        }
    }
}