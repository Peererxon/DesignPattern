using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.BuilderPattern
{
    
    public class PreparedDrink
    {
        public List<string> Ingredients = new List<string>();
        public int Milk;
        public int Water;
        public decimal Alcohol;

/*        public PreparedDrink(List<string> ingredients, int milk, int water, decimal alcohol)
        {
            Ingredients = ingredients;
            Milk = milk;
            Water = water;
            Alcohol = alcohol;
        }
*/
        public string Result;
    }
}
