using System;
namespace herenciayrelacionesgui.Clases
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string matricula, double precio, bool disponible) : base(matricula, precio, disponible)
        {
        }
        public Motocicleta(): base() {
        }
        public override double calcularPrestamo()
        {
            return this.PrecioMercado * 0.01;
        }
    }
}

