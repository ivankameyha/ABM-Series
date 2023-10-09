using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace AdmSeries.Clases
{
    internal class ClassSeries
    {
        public void mostrarSeries(DataGridView tablaSeries)
        {
            try
            {
                ClassConexion objetoConexion = new ClassConexion();

                String query = "SELECT * FROM Series";

                tablaSeries.DataSource = null;

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.abrirConexion());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaSeries.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos, error: " + ex.ToString());
            }
        }

        public void guardarSeries(TextBox titulo, TextBox descripcion, DateTimePicker fechaEstreno, TextBox estrellas, ComboBox genero, TextBox precioAlquiler, int atp, string estado)
        {
            try
            {
                ClassConexion objetoConexion = new ClassConexion();

                string query = "INSERT INTO Series (titulo, descripcion, fechaEstreno, estrellas, genero, precioAlquiler, atp, estado) VALUES (@titulo, @descripcion, @fechaEstreno, @estrellas, @genero, @precioAlquiler, @atp, @estado)";

                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.abrirConexion());
                myCommand.Parameters.AddWithValue("@titulo", titulo.Text);
                myCommand.Parameters.AddWithValue("@descripcion", descripcion.Text);
                myCommand.Parameters.AddWithValue("@fechaEstreno", fechaEstreno.Text);
                myCommand.Parameters.AddWithValue("@estrellas", estrellas.Text);
                myCommand.Parameters.AddWithValue("@genero", genero.Text);
                myCommand.Parameters.AddWithValue("@precioAlquiler", precioAlquiler.Text);
                myCommand.Parameters.AddWithValue("@atp", atp);
                myCommand.Parameters.AddWithValue("@estado", estado);

                myCommand.ExecuteNonQuery(); 

                MessageBox.Show("Se guardaron los datos correctamente");
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos, error: " + ex.ToString());
            }

        }

        public void modificarSeries(string id, TextBox titulo, TextBox descripcion, DateTimePicker fechaEstreno, TextBox estrellas, ComboBox genero, TextBox precioAlquiler, int atp, string estado)
        {
            try
            {
                ClassConexion objetoConexion = new ClassConexion();

                string query = "UPDATE Series SET titulo=@titulo, descripcion=@descripcion, fechaEstreno=@fechaEstreno, estrellas=@estrellas, genero=@genero, precioAlquiler=@precioAlquiler, atp=@atp, estado=@estado WHERE id=@id";

                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.abrirConexion());
                myCommand.Parameters.AddWithValue("@titulo", titulo.Text);
                myCommand.Parameters.AddWithValue("@descripcion", descripcion.Text);
                myCommand.Parameters.AddWithValue("@fechaEstreno", fechaEstreno.Text);
                myCommand.Parameters.AddWithValue("@estrellas", estrellas.Text);
                myCommand.Parameters.AddWithValue("@genero", genero.Text);
                myCommand.Parameters.AddWithValue("@precioAlquiler", precioAlquiler.Text);
                myCommand.Parameters.AddWithValue("@atp", atp);
                myCommand.Parameters.AddWithValue("@estado", estado);
                myCommand.Parameters.AddWithValue("@id", id);

                myCommand.ExecuteNonQuery();

                MessageBox.Show("Se modificaron los datos correctamente");
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se modificaron los datos, error: " + ex.ToString());
            }

        }

        public void anularSerie(string id, string estado)
        {
            try
            {
                ClassConexion objetoConexion = new ClassConexion();

                string query = "UPDATE Series SET estado='" + estado + "' WHERE id ='" + id + "';";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.abrirConexion());
                myComand.ExecuteNonQuery();

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se modificaron los datos, error: " + ex.ToString());
            }

        }

        public void eliminarSeries(string id)
        {
            try
            {
                ClassConexion objetoConexion = new ClassConexion();

                string query = "DELETE FROM Series WHERE id = '" + id + "';";

                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.abrirConexion());
                myCommand.ExecuteNonQuery(); 

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos, error: " + ex.ToString());
            }

        }
    }
}
