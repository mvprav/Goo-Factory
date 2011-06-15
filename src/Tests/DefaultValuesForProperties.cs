using NUnit.Framework;
using Tests.Factories;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class DefaultValuesForProperties
    {
        [Test]
        public void ShouldAssignPropertyNameAsDefaultValueToPropertyOfTypeString()
        {
            Organization createdOrganization =
                new OrganizationFactory().Create();
            createdOrganization.Name.Should().Be().EqualTo("Name");
        }
    }
}