using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Strategy
{
    internal class Context
    {
        private IStrategy _strategy;

        public IStrategy Strategy { 
            // con esto podemos cambiar la estrategia en tiempo de ejecucion
            set{
                _strategy = value; 
            } 
        }
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run()
        {
            // no se que es, pero corre
            _strategy.Run();
        }
    }
}
