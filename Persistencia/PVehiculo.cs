using System;
using System.Data;
using System.Data.SqlClient;
using gui.Persistencia;
using herenciayrelacionesgui.Clases;

namespace herenciayrelacionesgui.Persistencia
{
	public class PVehiculo
	{
		private static Conexion conexion = new Conexion();

        public static Boolean AddVehiculo(Vehiculo v)
        {
            string sql = "INSERT INTO vehiculo (matricula, preciomercado, disponible, tipo) VALUES (@matricula, @preciomercado, @disponible, @tipo)";
            string tipo = v.GetType().Name;
            
            SqlParameter[] parametros = {
                new SqlParameter("@matricula", SqlDbType.VarChar) { Value = v.Matricula },
                new SqlParameter("@preciomercado", SqlDbType.Decimal) { Value = v.PrecioMercado},
                new SqlParameter("@disponible", SqlDbType.Int) { Value = v.Disponible },
                new SqlParameter("@tipo", SqlDbType.VarChar) { Value = tipo }

            };

            Console.WriteLine("Ingresado con éxito");
            bool encontrado = conexion.Consulta(sql, parametros);

            return encontrado;
        }

        public static Boolean UpdateVehiculo(Vehiculo v)
        {
            string sql = "UPDATE vehiculo SET preciomercado=@preciomercado, disponible=@disponible, tipo=@tipo WHERE matricula=@matricula";
            string tipo = v.GetType().Name;

            SqlParameter[] parametros = {
                new SqlParameter("@matricula", SqlDbType.VarChar) { Value = v.Matricula },
                new SqlParameter("@preciomercado", SqlDbType.Decimal) { Value = v.PrecioMercado},
                new SqlParameter("@disponible", SqlDbType.Int) { Value = v.Disponible },
                new SqlParameter("@tipo", SqlDbType.VarChar) { Value = tipo }

            };

            Console.WriteLine("Modificado con éxito");
            bool encontrado = conexion.Consulta(sql, parametros);
            return encontrado;
        }

        public static Boolean DeleteVehiculo(string matricula)
        {
            string sql = "DELETE vehiculo WHERE matricula=@matricula";

            SqlParameter[] parametros = {
                new SqlParameter("@matricula", SqlDbType.VarChar) { Value = matricula }
            };

            Console.WriteLine("Eliminado con éxito");
            bool encontrado = conexion.Consulta(sql, parametros);
            return encontrado;
        }

        public static Vehiculo GetVehiculo(string matricula)
        {
            string sql = "SELECT * FROM vehiculo WHERE matricula=@matricula";

            SqlParameter[] parametros = {
                new SqlParameter("@matricula", SqlDbType.VarChar) { Value = matricula }
            };

            Console.WriteLine("Conseguido con éxito");
            DataSet data = conexion.Seleccion(sql, parametros);
            DataRow row = data.Tables[0].Rows[0];
            if (row["tipo"].ToString().Equals("Automovil"))
            {
                return new Automovil(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"]));
            }
            else {
                return new Motocicleta(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"]));
            }

        }
        public static List<Vehiculo> GetVehiculos()
        {
            string sql = "SELECT * FROM vehiculo";

            Console.WriteLine("Conseguidos con éxito");
            DataSet data = conexion.Seleccion(sql);
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (row["tipo"].ToString().Equals("Automovil"))
                {
                    vehiculos.Add(new Automovil(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"])));
                }
                else
                {
                    vehiculos.Add(new Motocicleta(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"])));
                }
            }
            return vehiculos;
        }
        public static List<Vehiculo> GetVehiculosDisponibles()
        {
            string sql = "SELECT * FROM vehiculo WHERE disponible=1";

            Console.WriteLine("Conseguidos con éxito");
            DataSet data = conexion.Seleccion(sql);
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (row["tipo"].ToString().Equals("Automovil"))
                {
                    vehiculos.Add(new Automovil(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"])));
                }
                else
                {
                    vehiculos.Add(new Motocicleta(row["matricula"].ToString(), Convert.ToDouble(row["preciomercado"]), Convert.ToBoolean(row["disponible"])));
                }
            }
            return vehiculos;
        }
    }
}

