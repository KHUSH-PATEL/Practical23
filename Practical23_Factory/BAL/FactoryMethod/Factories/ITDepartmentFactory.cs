using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.Factories
{
    public class ITDepartmentFactory : IDepartmentBaseFactory
    {
        public IDepartmentManager CreateDepartmentManager()
        {
            return new ITDepartmentManager();
        }
    }
}
