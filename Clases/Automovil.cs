using System;
namespace herenciayrelacionesgui.Clases
{
	public class Automovil : Vehiculo
	{
		public Automovil(string matricula, double precio, bool disponible) : base(matricula,precio,disponible)
		{
		}
        public override double calcularPrestamo()
        {
            return this.PrecioMercado * 0.002;
        }
    }
}

