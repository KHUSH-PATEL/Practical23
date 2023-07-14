namespace Practical23_Factory.BAL.FactoryMethod.DepartmentManagers
{
    public class AdminDepartmentManager : IDepartmentManager
    {
        public decimal CalculateOverTime(int hours)
        {
            return hours * 200;
        }
    }
}
