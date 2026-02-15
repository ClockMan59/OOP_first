using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Fundamentals_Library
{
    public abstract class Person
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }

        protected Person(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым");

            if (age < 0 || age > 120)
                throw new ArgumentException("Некорректный возраст");

            Name = name;
            Age = age;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{this.GetType().Name}: {Name}, {Age} years old");
        }
    }
}
