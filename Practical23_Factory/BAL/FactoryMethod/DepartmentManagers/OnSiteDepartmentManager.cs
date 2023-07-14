namespace Practical23_Factory.BAL.FactoryMethod.DepartmentManagers
{
    public class OnSiteDepartmentManager : IDepartmentManager
    {
        public decimal CalculateOverTime(int hours)
        {
            return hours * 500;
        }
    }
}
