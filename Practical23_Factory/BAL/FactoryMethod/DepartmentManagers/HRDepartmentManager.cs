namespace Practical23_Factory.BAL.FactoryMethod.DepartmentManagers
{
    public class HRDepartmentManager : IDepartmentManager
    {
        public decimal CalculateOverTime(int hours)
        {
            return hours * 300;
        }
    }
}
