using System;
namespace herenciayrelacionesgui.Clases
{
	public class Prestamo
	{
		private DateTime fecha;
		private Vehiculo vehiculo;
		private double precio;
		private string cedulaCliente;
		private int celularCliente;

		public Prestamo(DateTime fecha, Vehiculo vehiculo, double precio, string cedulaCliente, int celularCliente)
		{
			this.Fecha = fecha;
			this.Vehiculo = vehiculo;
			this.Precio = precio;
			this.CedulaCliente = cedulaCliente;
			this.CelularCliente = celularCliente;
		}

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public double Precio { get => precio; set => precio = value; }
        public string CedulaCliente { get => cedulaCliente; set => cedulaCliente = value; }
        public int CelularCliente { get => celularCliente; set => celularCliente = value; }
    }
}

