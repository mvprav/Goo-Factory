using NUnit.Framework;

namespace Tests
{
    public static class AssertionExtenstions
    {
        public static Assertions Should(this object actual)
        {
            return new Assertions(actual);
        }
    }

    public class Assertions
    {
        private readonly object actual;

        public Assertions(object actual)
        {
            this.actual = actual;
        }

        public Comparision Be()
        {
            return new Comparision(actual);

        }

        public void BeNull()
        {
            Assert.IsNull(actual);
        }
    }

    public class Comparision
    {
        private readonly object actual;

        public Comparision(object actual)
        {
            this.actual = actual;
        }

        public void GreaterThan(object expected)
        {
            Assert.That(actual, Is.GreaterThan(expected));
        }

        public void EqualTo(object expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        public void Empty()
        {
            Assert.IsEmpty(actual.ToString());
        }

        public void Null()
        {
            Assert.IsNull(actual);
        }
    }
}