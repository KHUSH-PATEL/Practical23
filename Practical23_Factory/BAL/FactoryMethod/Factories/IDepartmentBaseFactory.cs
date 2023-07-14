using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.Factories
{
    public interface IDepartmentBaseFactory
    {
        public abstract IDepartmentManager CreateDepartmentManager();
    }
}
