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
                YearsOfService = 6, // > 5 лет, бонус будет больше
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

            // Метод один и тот же, но поведение внутри разное
            payroll.ProcessSalary(employee); // Обычный бонус (10%)
            payroll.ProcessSalary(manager);  // Менеджерский бонус (20%)

            // 5. Тест защиты (Инкапсуляция)
            // employee.Salary = -100; // Это вызовет ошибку компиляции (сеттер protected) или рантайма, если бы был public
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}