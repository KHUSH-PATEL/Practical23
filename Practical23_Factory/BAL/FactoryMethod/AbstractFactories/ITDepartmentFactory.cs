using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public class ITDepartmentFactory : IndoorDepartmentFactory
    {
        public override IDepartmentManager CreateDepartmentManager()
        {
            return new ITDepartmentManager();
        }
    }
}
