using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.AbstractFactories
{
    public class SalesDepartmentFactory : OutdootDepartmentFactory
    {
        public override IDepartmentManager CreateDepartmentManager()
        {
            return new SalesDepartmentManager();
        }
    }
}
