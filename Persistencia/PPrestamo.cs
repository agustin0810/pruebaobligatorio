using System;
using System.Data;
using System.Data.SqlClient;
using gui.Persistencia;
using herenciayrelacionesgui.Clases;

namespace herenciayrelacionesgui.Persistencia
{
    public class PPrestamo
    {
        private static Conexion conexion = new Conexion();

        public static Boolean AddPrestamo(Prestamo p)
        {
            string sql = "INSERT INTO prestamo (fecha, matriculavehiculo, precio, cedulacliente, celularcliente) VALUES (@fecha, @idvehiculo, @precio, @cedulacliente, @celularcliente)";

            SqlParameter[] parametros = {
                new SqlParameter("@fecha", SqlDbType.DateTime) { Value = p.Fecha },
                new SqlParameter("@idvehiculo", SqlDbType.VarChar) { Value = p.Vehiculo.Matricula},
                new SqlParameter("@precio", SqlDbType.Decimal) { Value = p.Precio },
                new SqlParameter("@cedulacliente", SqlDbType.VarChar) { Value = p.CedulaCliente },
                new SqlParameter("@celularcliente", SqlDbType.Int) { Value = p.CelularCliente }

            };

            Console.WriteLine("Ingresado con éxito");
            bool encontrado = conexion.Consulta(sql, parametros);
            return encontrado;
        }

        public static List<Prestamo> GetPrestamos()
        {
            string sql = "SELECT * FROM prestamo";

            Console.WriteLine("Conseguidos con éxito");
            DataSet data = conexion.Seleccion(sql);
            List<Prestamo> prestamos = new List<Prestamo>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                
                prestamos.Add(new Prestamo(Convert.ToDateTime(row["fecha"]), PVehiculo.GetVehiculo(row["matriculavehiculo"].ToString()), Convert.ToDouble(row["precio"]), row["cedulacliente"].ToString(), Convert.ToInt32(row["celularcliente"])));
                
            }
            return prestamos;
        }
    }
}

