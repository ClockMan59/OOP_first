using System;
using System.Collections.Generic;

namespace task4
{
    public sealed class PrototypeRegistry
    {
        private static readonly Lazy<PrototypeRegistry> _instance =
            new Lazy<PrototypeRegistry>(() => new PrototypeRegistry());

        private Dictionary<string, Computer> _prototypes;

        private PrototypeRegistry()
        {
            _prototypes = new Dictionary<string, Computer>();

            _prototypes["office"] = new OfficeComputerFactory().Construct();
            _prototypes["gaming"] = new GamingComputerFactory().Construct();
            _prototypes["home"] = new HomeComputerFactory().Construct();
        }

        public static PrototypeRegistry Instance => _instance.Value;

        public Computer GetPrototype(string key)
        {
            if (_prototypes.TryGetValue(key.ToLower(), out Computer prototype))
            {
                return prototype.DeepCopy();
            }
            throw new KeyNotFoundException($"Прототип '{key}' не найден.");
        }
    }
}