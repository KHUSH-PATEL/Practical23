using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public class OnSIteDepartmentFactory : OutdootDepartmentFactory
    {
        public override IDepartmentManager CreateDepartmentManager()
        {
            return new OnSiteDepartmentManager();
        }
    }
}
