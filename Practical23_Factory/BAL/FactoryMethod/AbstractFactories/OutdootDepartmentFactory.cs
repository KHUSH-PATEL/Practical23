using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;
using Practical23_Factory.BAL.FactoryMethod.Factories;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public abstract class OutdootDepartmentFactory : IDepartmentBaseFactory
    {
        public abstract IDepartmentManager CreateDepartmentManager();
    }
}
