namespace Practical23_Factory.BAL.FactoryMethod.DepartmentManagers
{
    public class ITDepartmentManager : IDepartmentManager
    {
        public decimal CalculateOverTime(int hours)
        {
            return hours * 100;
        }
    }
}
