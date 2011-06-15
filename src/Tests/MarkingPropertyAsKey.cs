using NUnit.Framework;
using Tests.Factories;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class MarkingPropertyAsKey
    {
        [Test]
        public void ShouldNotProvideAnyValueToPropertyMarkedAsKey()
        {
            Organization createdOrganization =
               new OrganizationFactory().HasKey(organization => organization.Id).Create();
            createdOrganization.Id.Should().Be().EqualTo(0);
        }

        [Test]
        public void HavingMoreThanOnePropertyAsKey()
        {
            Organization createdOrganization =
              new OrganizationFactory().HasKey(organization => organization.Id).HasKey(organization => organization.Code).Create();
            createdOrganization.Code.Should().Be().Null();
            createdOrganization.Id.Should().Be().EqualTo(0);
        }
    }
}