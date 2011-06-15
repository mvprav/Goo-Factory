using Goo.src;
using NUnit.Framework;
using Tests.Factories;
using Tests.model;

namespace Tests
{
    [TestFixture]
    public class AssigningSequenceToProperty
    {
        [Test]
        public void ShouldAssignSequenceToProperty()
        {
            Organization createdOrgnization =
                new OrganizationFactory().HasValue(organization => organization.Name, new FactorySequence("name{0}")).
                    Create();
            createdOrgnization.Name.Should().Be().EqualTo("name1");
        }

        [Test]
        public void ShouldOverrideAlreadyAssignedSequence()
        {
            Organization createdOrgnization = new OrganizationFactory().
                HasValue(organization => organization.Name, new FactorySequence("name{0}")).
                HasValue(organization => organization.Name, new FactorySequence("newname{0}")).Create();
            createdOrgnization.Name.Should().Be().EqualTo("newname" + FactorySequence.Count);
        }

        [Test]
        public void ShouldOverrideAlreadyAssignedValue()
        {
            Organization createdOrgnization = new OrganizationFactory().
                HasValue(organization => organization.Name, "namevalue").
                HasValue(organization => organization.Name, new FactorySequence("newname{0}")).Create();
            createdOrgnization.Name.Should().Be().EqualTo("newname" + FactorySequence.Count);
        }
    }
}