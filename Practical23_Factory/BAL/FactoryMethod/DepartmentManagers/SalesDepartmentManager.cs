namespace Practical23_Factory.BAL.FactoryMethod.DepartmentManagers
{
    public class SalesDepartmentManager : IDepartmentManager
    {
        public decimal CalculateOverTime(int hours)
        {
            return hours * 400;
        }
    }
}
