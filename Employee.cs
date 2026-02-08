namespace OOP_Fundamentals_Library
{
    public class Employee : Person
    {
        private decimal _salary;

        public decimal Salary
        {
            get => _salary;
            protected set
            {
                if (value < 0) throw new ArgumentException("Зарплата не может быть отрицательной");
                _salary = value;
            }
        }

        public string Position { get; protected set; }
        public int YearsOfService { get; set; }
        public bool HasCertification { get; set; }

        public Employee(string name, int age, decimal salary, string position)
            : base(name, age)
        {
            Salary = salary;
            Position = position;
        }

        public void IncreaseSalary(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма повышения должна быть больше нуля");
            Salary += amount;
        }

        public virtual decimal CalculateBonus()
        {
            decimal bonus = Salary * 0.1m;

            if (YearsOfService > 5) bonus += 500;
            if (HasCertification) bonus += 300;

            return bonus;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Employee: {Name}, {Age} y.o., Position: {Position}, Salary: {Salary}");
        }
    }
}
