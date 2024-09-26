using System.Collections.Generic;

namespace _Scripts.Car.Checker
{
    public class CarReader
    {
        private readonly List<ICheck> _checks;

        public CarReader(List<ICheck> checks)
        {
            _checks = checks;
        }

        public void Check()
        {
            foreach (var check in _checks) check.Check();
        }
    }
}