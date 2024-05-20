using System.Data;
using System.Data.SqlClient;
namespace gui.Persistencia
{
    public class Conexion
    {
        protected static string CadenaDeConexion
        {
            get
            {
                return @"Data Source=localhost,1433;Initial Catalog=prueba;User ID=sa;Password=MiPassw0rd!1521;";
                //return @"Data Source=localhost,1433;Initial Catalog=prueba;Integrated Security=True;";
            }
        }
        public bool Consulta(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                SqlConnection Conexión = new SqlConnection(CadenaDeConexion);
                SqlCommand comando = new SqlCommand(sql, Conexión);

                //Agregamos parametros a la consulta si existen
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }

                Conexión.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                Conexión.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error en Conexión.Consulta, sql = " + sql, e);
            }
        }

        public DataSet Seleccion(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                using (SqlConnection conexión = new SqlConnection(CadenaDeConexion))
                {
                    // Creamos el comando SQL con la consulta y la conexión
                    SqlCommand comando = new SqlCommand(sql, conexión);

                    //Agregamos parametros a la consulta si existen
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    // Creamos el adaptador de datos
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    // Creamos el DataSet para almacenar los resultados
                    DataSet resultado = new DataSet();

                    // Abrimos la conexión
                    conexión.Open();

                    // Llenamos el DataSet con los resultados de la consulta
                    adaptador.Fill(resultado);

                    // Cerramos la conexión y liberamos recursos
                    conexión.Close();

                    // Devolvemos el DataSet con los resultados
                    return resultado;
                }
            }
            catch (Exception e)
            {
                // Capturamos y relanzamos cualquier excepción ocurrida durante la ejecución
                throw new Exception("Error en Conexión.Selección, sql = " + sql, e);
            }
        }
    }
}

