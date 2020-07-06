using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos 

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection("Data Source = .\\SQLEXPRESS; Database = correo-sp-2017;Trusted_Connection=True;");
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Realiza un insert en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true si logra insertar los datos correctamente, false caso contrario</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                string query = $"INSERT INTO Paquetes (direccionEntrega,trackingID, alumno) VALUES( '{p.DireccionEntrega}', '{p.TrackingID}', '{"Alessandra Fernandes"}')";

                comando.CommandText = query;
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                retorno = false;
                string typeString = ex.GetType().FullName;
                throw new Exception(typeString, ex);
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
            return retorno;
        }

        #endregion




    }
}
