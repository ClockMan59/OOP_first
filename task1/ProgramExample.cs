using OOP_Fundamentals_Library;
using OOP_Fundamentals_Library.OOP_Fundamentals_Library;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 1. Создание объектов (проверка валидации и конструкторов)
            var customer = new Customer("John Doe", 30);

            var employee = new Employee("Alice Smith", 25, 50000, "Developer")
            {
                YearsOfService = 3,
                HasCertification = true
            };

            var manager = new Manager("Bob Boss", 40, 80000, "IT")
            {
                YearsOfService = 6,
                HasCertification = true
            };

            // 2. Работа с инкапсулированным списком
            manager.AddTeamMember(employee);

            // 3. Вывод информации (Полиморфизм PrintInfo)
            Console.WriteLine("--- Info ---");
            customer.PrintInfo();
            employee.PrintInfo();
            manager.PrintInfo();
            Console.WriteLine();

            // 4. Расчет зарплат (Полиморфизм CalculateBonus)
            Console.WriteLine("--- Payroll ---");
            var payroll = new PayrollSystem();

            payroll.ProcessSalary(employee);
            payroll.ProcessSalary(manager);

            // 5. Тест защиты (Инкапсуляция)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}