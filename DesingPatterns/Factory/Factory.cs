using System;
namespace DesingPatterns.Factory
{
    // Para cada nuevo producto hay que crear una nueva fabrica porque se asume que el comportamiento
    // puede ser distinto


	//Creator
	public abstract class SaleFactory
	{
		public abstract Isale GetIsale();
	}

    //Concrete creator
    public class StoreSaleFactory : SaleFactory
    {
        private decimal _extra;

        //El constructor debe ser el unico encargado de recibir estas dependencias
        // para los objetos
        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }

        // Metoodo que no recibe parametro
        public override Isale GetIsale()
        {
            return new StoreSale(_extra);
        }
    }

    public class InternetSaleFactory : SaleFactory
    {
        private decimal _disccount;

        public InternetSaleFactory(decimal disccount)
        {
            _disccount = disccount;
        }

        public override Isale GetIsale()
        {
            return new InternetSale(_disccount);
        }
    }

    // Concrete product
    public class StoreSale : Isale
    {
        private decimal _extra;

        public StoreSale(decimal extra)
		{
			_extra = extra;
		}

        public void Sell(decimal total)
        {
			Console.WriteLine($"La venta en TIENDA tiene un total de {total + _extra}");
        }
    }

    public class InternetSale : Isale
    {
        private decimal _disccount;

        public InternetSale(decimal disccount)
        {
            _disccount = disccount;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en TIENDA tiene un total de {total - _disccount}");
        }
    }

    // Product
    public interface Isale
	{
		public void Sell(decimal total);
	}

}

