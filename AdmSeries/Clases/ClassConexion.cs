using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdmSeries.Clases
{
    internal class ClassConexion
    {
        MySqlConnection conexion = new MySqlConnection();

        string cadenaConexion = "";
        static string Servidor { get; set; }
        static string Usuario { get; set; }
        static string Contraseña { get; set; }
        static string BaseDatos { get; set; }
        static string Puerto { get; set; }

        bool conexionAbierta = false;

        // metodo para establecer los valores de conexión
        public void SetConexionParametros(string servidor, string usuario, string contraseña, string baseDatos, string puerto)
        {
            Servidor = servidor;
            Usuario = usuario;
            Contraseña = contraseña;
            BaseDatos = baseDatos;
            Puerto = puerto;
        }

        public MySqlConnection abrirConexion()
        {
            try
            {
                cadenaConexion = $"Server={Servidor};Port={Puerto};User ID={Usuario};Password={Contraseña};Database={BaseDatos}";
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                conexionAbierta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos, error: " + ex.ToString());
            }

            return conexion;
        }

        public bool validarConexion()
        {
            if (conexionAbierta == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ////codigo anterior
        //static string servidor = "localhost";
        //static string bd = "admseries";
        //static string usuario = "root";
        //static string password = "admin";
        //static string puerto = "3306";

        //string CadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        //public MySqlConnection abrirConexion()
        //{
        //    try
        //    {
        //        conexion.ConnectionString = CadenaConexion;
        //        conexion.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se conectó a la base de datos, error: " + ex.ToString());
        //    }

        //    return conexion;
        //}

        public void cerrarConexion()
        {
            conexion.Close();
        }
    }
}
