using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.BuilderPattern
{
    public class PreparedAlcoholicDrinkConcreteBuilder : IBuilder
    {
        //se usa el objeto como propiedad aqui para no atar el tipo de objeto al builder abstracto interfaz

        private PreparedDrink _preparedDrink; //Lo acomplado es la clase, no la interfaz

        public PreparedAlcoholicDrinkConcreteBuilder()
        {
           Reset();
        }

        public PreparedDrink GetPreparedDrink() => _preparedDrink;
        public void AddIngredients(string ingredients)
        {
            if (_preparedDrink.Ingredients == null)
            {
                _preparedDrink.Ingredients = new List<string>();
            }

            _preparedDrink.Ingredients.Add(ingredients);
        }

        public void Mix()
        {
            //Este agregate es para evitar hacer un for. Se parece a un join en js
            string ingredients = _preparedDrink.Ingredients.Aggregate( (i,j)=> i+ ", " + j);
            _preparedDrink.Result = $"Bebida {_preparedDrink.Alcohol} preparada con los siguientes ingredientes: {ingredients}";
            Console.WriteLine("Mezclamos los ingredientes");
        }

        public void Reset()
        {
           _preparedDrink = new PreparedDrink();  
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Listo para beberse");
        }

        public void SetAlchohol(decimal alchohol)
        {
            _preparedDrink.Alcohol= alchohol;
        }

        public void SetMilk(int milk)
        {
            _preparedDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparedDrink.Water = water;
        }
    }
}
