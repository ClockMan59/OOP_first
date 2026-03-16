using System;


namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Паттерн Строитель (Builder) ===");
            Computer customPc = new ComputerBuilder()
                .WithCPU("Intel Core i9")
                .WithRAM(64)
                .WithGPU("NVIDIA RTX 4090")
                .WithComponent("Water Cooling")
                .WithComponent("2TB NVMe SSD")
                .Build();
            Console.WriteLine("Кастомный ПК:");
            customPc.Display();

            Console.WriteLine("=== 2. Паттерн Прототип (Prototype) ===");
            Computer original = new OfficeComputerFactory().Construct();

            Computer shallowClone = original.ShallowCopy();
            Computer deepClone = original.DeepCopy();

            // Меняем списки в клонах
            shallowClone.AdditionalComponents.Add("Wi-Fi Adapter (Shallow)");
            deepClone.AdditionalComponents.Add("Bluetooth Adapter (Deep)");

            Console.WriteLine("Оригинал после изменений в клонах:");
            original.Display();

            Console.WriteLine("Поверхностный клон (Shallow):");
            shallowClone.Display();

            Console.WriteLine("Глубокий клон (Deep):");
            deepClone.Display();


            Console.WriteLine("=== 3. Паттерн Одиночка (Singleton) ===");
            PrototypeRegistry registry1 = PrototypeRegistry.Instance;
            PrototypeRegistry registry2 = PrototypeRegistry.Instance;

            bool isSameInstance = object.ReferenceEquals(registry1, registry2);
            Console.WriteLine($"registry1 и registry2 ссылаются на один объект? {isSameInstance}\n");

            Console.WriteLine("Берем прототип 'gaming' из реестра и меняем его...");
            Computer myGamingPc = registry1.GetPrototype("gaming");
            myGamingPc.RAM = 128;
            myGamingPc.AdditionalComponents.Add("Stream Deck");

            Console.WriteLine("Мой модифицированный ПК:");
            myGamingPc.Display();

            Console.WriteLine("Снова берем 'gaming' из реестра (проверяем, что оригинал не сломался):");
            Computer untouchedGamingPc = registry1.GetPrototype("gaming");
            untouchedGamingPc.Display();

            Console.ReadLine();
        }
    }
}