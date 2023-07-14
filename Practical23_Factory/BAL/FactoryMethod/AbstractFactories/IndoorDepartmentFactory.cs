using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;
using Practical23_Factory.BAL.FactoryMethod.Factories;
using Practical23_Factory.Dto;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public abstract class IndoorDepartmentFactory : IDepartmentBaseFactory
    {
        public abstract IDepartmentManager CreateDepartmentManager();
    }
}
