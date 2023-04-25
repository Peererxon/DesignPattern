using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;

        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PreparedMargarita()
        {
            _builder.AddIngredients("Tequila");
            _builder.SetAlchohol(1);
            _builder.Mix();
            _builder.Rest(1000);
        }

        public void PreparedPiñaColada()
        {
            _builder.SetWater(1);
            _builder.AddIngredients("Leche");
            _builder.AddIngredients("Piña");
            _builder.SetAlchohol(1);
            _builder.Mix();
            _builder.Rest(500);
        }
    }
}
