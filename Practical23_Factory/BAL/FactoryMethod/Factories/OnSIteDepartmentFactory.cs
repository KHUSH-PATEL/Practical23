using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.Factories
{
    public class OnSIteDepartmentFactory : IDepartmentBaseFactory
    {
        public IDepartmentManager CreateDepartmentManager()
        {
            return new OnSiteDepartmentManager();
        }
    }
}
