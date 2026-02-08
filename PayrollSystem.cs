namespace OOP_Fundamentals_Library
{
    namespace OOP_Fundamentals_Library
    {
        public class PayrollSystem
        {
            public void ProcessSalary(Employee emp)
            {
                Console.WriteLine($"Processing payroll for {emp.Name}...");

                decimal bonus = emp.CalculateBonus();
                decimal totalPayment = emp.Salary + bonus;

                Console.WriteLine($"  Base Salary: {emp.Salary}");
                Console.WriteLine($"  Bonus: {bonus}");
                Console.WriteLine($"  Total Transfer: {totalPayment}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
