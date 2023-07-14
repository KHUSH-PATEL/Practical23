using Practical23_Factory.BAL.FactoryMethod.AbstractFactories;
using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public class HRDepartmentFactory : IndoorDepartmentFactory
    {
        public override IDepartmentManager CreateDepartmentManager()
        {
            return new HRDepartmentManager();
        }
    }
}
