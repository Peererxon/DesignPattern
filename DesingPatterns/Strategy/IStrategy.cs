using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Strategy
{
    internal interface IStrategy
    {
        // es para un vehiculo desplazarse
        public void Run();
    }
}
