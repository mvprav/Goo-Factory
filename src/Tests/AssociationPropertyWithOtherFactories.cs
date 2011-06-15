using Goo.src;
using NUnit.Framework;
using Tests.Factories;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class AssociationPropertyWithOtherFactories
    {
         
        [Test]
        public void ShouldAssociatePropertyWithDifferentFactory()
        {
            Organization createdOrgnization =
                new OrganizationFactory().Associate(organization => organization.DefaultAdmin).With<AdminFactory>().Create();
            createdOrgnization.DefaultAdmin.Name.Should().Be().EqualTo("adminname"+FactorySequence.Count);
        }

        [Test]
        public void ShouldOverrideAlreadyAssociatedFactoryForAPropertWithDifferentFactory()
        {
            Organization createdOrgnization =
                new OrganizationFactory().Associate(organization => organization.DefaultAdmin).With<AdminFactory>().
                    Associate(organization => organization.DefaultAdmin).With<SuperAdminFactory>().Create();
            createdOrgnization.DefaultAdmin.Name.Should().Be().EqualTo("superadminname" + FactorySequence.Count);
        }
    }
}