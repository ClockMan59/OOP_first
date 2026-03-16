using System;
using System.Collections.Generic;

namespace task4
{
    public class Computer
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public string GPU { get; set; }
        public List<string> AdditionalComponents { get; set; } = new List<string>();

        public void Display()
        {
            Console.WriteLine($"CPU: {CPU}, RAM: {RAM}GB, GPU: {GPU}");
            Console.WriteLine($"Доп. компоненты: {string.Join(", ", AdditionalComponents)}");
            Console.WriteLine();
        }

        public Computer ShallowCopy()
        {
            return (Computer)this.MemberwiseClone();
        }

        public Computer DeepCopy()
        {
            Computer clone = (Computer)this.MemberwiseClone();
            clone.AdditionalComponents = new List<string>(this.AdditionalComponents);
            return clone;
        }
    }
}