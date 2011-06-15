using Goo.src;
using Tests.model;

namespace Tests.Factories
{
    public class SuperAdminFactory:Factory<User>
    {
        public SuperAdminFactory()
        {
            HasValue(user => user.Name, new FactorySequence("superadminname{0}"));
        }
    }
}