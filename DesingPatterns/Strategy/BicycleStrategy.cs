using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Strategy
{
    internal class BicycleStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una bicicleta y pedaleo");
        }
    }
}
