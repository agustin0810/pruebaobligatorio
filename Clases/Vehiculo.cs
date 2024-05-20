using System;
namespace herenciayrelacionesgui.Clases
{
	public abstract class Vehiculo
	{
		private string matricula;
		private double precioMercado;
		private bool disponible;

		public Vehiculo(string matricula, double precioMercado, bool disponible)
		{
			this.Matricula = matricula;
			this.PrecioMercado = precioMercado;
			this.Disponible = disponible;
		}
		public Vehiculo() { }

        public string Matricula { get => matricula; set => matricula = value; }
        public double PrecioMercado { get => precioMercado; set => precioMercado = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        public override string ToString()
        {
            return $"Matricula: {this.matricula}, Precio: {this.precioMercado}";
        }
        public abstract double calcularPrestamo();
    }
}

