using Goo.src;
using NUnit.Framework;
using Tests.Factories;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class AssigningValuesToProperty
    {
        [TestCase]
        public void ShouldAssignValuesForProperty()
        {
            Organization createdOrganization =
                new OrganizationFactory().HasValue(organization => organization.Name, "org name").Create();
            createdOrganization.Name.Should().Be().EqualTo("org name");
        }

        [Test]
        public void ShouldOverrideTheAlreadyAssignedValues()
        {
            Organization createdOrganization =
                new OrganizationFactory().
                    HasValue(organization => organization.Name, "org name").
                    HasValue(organization => organization.Name, "overriden name").
                    Create();
            createdOrganization.Name.Should().Be().EqualTo("overriden name");
        }

        [Test]
        public void ShouldOverrideAlreadyAssociatedSequence()
        {
            Organization createdOrganization =
                new OrganizationFactory().
                    HasValue(organization => organization.Name, new FactorySequence("name{0}")).
                    HasValue(organization => organization.Name, "namevalue").Create();

            createdOrganization.Name.Should().Be().EqualTo("namevalue");
        }

        [Test]
        public void ShouldOverrideAlreadyAssociatedFactory()
        {
            Organization createdOrganization =
             new OrganizationFactory().
                 Associate(organization => organization.DefaultAdmin).With<AdminFactory>().
                 HasValue(organization => organization.DefaultAdmin, new User(){Name = "new name"}).Create();
            createdOrganization.DefaultAdmin.Name.Should().Be().EqualTo("new name");
        }
    }
}