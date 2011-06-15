using Goo.src;
using Tests.model;

namespace Tests.Factories
{
    public class AdminFactory:Factory<User>
    {
        public AdminFactory()
        {
            HasValue(user => user.Name, new FactorySequence("adminname{0}"));
        }
    }
}