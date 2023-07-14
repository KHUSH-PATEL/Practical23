using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;

namespace Practical23_Factory.BAL.FactoryMethod.Factories
{
    public class SalesDepartmentFactory : IDepartmentBaseFactory
    {
        public IDepartmentManager CreateDepartmentManager()
        {
            return new SalesDepartmentManager();
        }
    }
}
