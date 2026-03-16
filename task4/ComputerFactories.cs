

namespace task4
{
    public interface IComputerFactory
    {
        Computer Construct();
    }

    public class OfficeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i3")
                .WithRAM(8)
                .WithGPU("Integrated Intel UHD")
                .WithComponent("Office Mouse")
                .WithComponent("Office Keyboard")
                .Build();
        }
    }

    public class GamingComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 7")
                .WithRAM(32)
                .WithGPU("NVIDIA RTX 4080")
                .WithComponent("Mechanical Keyboard")
                .WithComponent("RGB Mouse")
                .WithComponent("144Hz Monitor")
                .Build();
        }
    }

    public class HomeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5")
                .WithRAM(16)
                .WithGPU("NVIDIA GTX 1660")
                .WithComponent("Webcam")
                .WithComponent("Speakers")
                .Build();
        }
    }
}