namespace OOP_Fundamentals_Library
{
    namespace OOP_Fundamentals_Library
    {
        public class Manager : Employee
        {
            public string Department { get; private set; }

            private List<Employee> _team = new();
            public IReadOnlyCollection<Employee> Team => _team.AsReadOnly();

            public Manager(string name, int age, decimal salary, string department)
                : base(name, age, salary, "Manager")
            {
                Department = department;
            }

            public void AddTeamMember(Employee emp)
            {
                if (emp == null) throw new ArgumentNullException(nameof(emp));
                _team.Add(emp);
            }

            public void AssignTaskToEmployee(Employee emp, string task)
            {
                if (_team.Contains(emp))
                {
                    Console.WriteLine($"Manager {Name} assigning task '{task}' to {emp.Name}");
                }
                else
                {
                    Console.WriteLine($"Error: {emp.Name} is not in {Name}'s team.");
                }
            }

            public override decimal CalculateBonus()
            {
                decimal baseBonus = Salary * 0.2m;

                if (YearsOfService > 5) baseBonus += 500;
                if (HasCertification) baseBonus += 300;

                return baseBonus;
            }

            public override void PrintInfo()
            {
                Console.WriteLine($"Manager: {Name}, Dept: {Department}, Team Size: {Team.Count}");
            }
        }
    }
}
