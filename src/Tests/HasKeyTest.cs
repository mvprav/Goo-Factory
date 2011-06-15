using Goo;
using NUnit.Framework;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class HasKeyTest
    {
        [Test]
        public void ShouldProvideTheDefaultValueOfTheProperty()
        {
            var key1 = new HasKey<Organization, int>(organization => organization.Id);
            object value = key1.Value();
            value.Should().Be().EqualTo(0);

            var key2 = new HasKey<Organization, string>(organization => organization.Code);
            key2.Value().Should().Be().Null();
        }
    }
}