using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdmSeries
{
    public partial class Conexion : Form
    {
        public Conexion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Clases.ClassConexion objetoConexion = new Clases.ClassConexion();
            objetoConexion.cerrarConexion();
            this.Close();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string server = txtServidor.Text;
            string db = txtBaseDatos.Text;
            string user = txtUsuario.Text;
            string password = txtContraseña.Text;
            string port = txtPuerto.Text;

            Clases.ClassConexion objetoConexion = new Clases.ClassConexion();

            objetoConexion.SetConexionParametros(server, user, password, db, port);

            if (server != "" && db != "" && user != "" && password != "" && port != "")
            {
                objetoConexion.abrirConexion();

                if(objetoConexion.validarConexion())
                {
                MessageBox.Show("Se conectó a la base de datos");

                Inicio formInicio = new Inicio();

                formInicio.Show();
                this.Hide();

                formInicio.FormClosing += frmClosing;
                }
                else
                {
                    MessageBox.Show("La conexión no es válida");
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa los campos");
            }


            //// validacion de datos codigo anterior
            //if (server == "localhost" && db == "admseries" && user == "root" && password == "admin" && port == "3306")
            //{
            //    objetoConexion.abrirConexion();

            //    MessageBox.Show("Se conectó a la base de datos");

            //    Inicio formInicio = new Inicio();

            //    formInicio.Show();
            //    this.Hide();

            //    formInicio.FormClosing += frmClosing;

            //}
            //else
            //{
            //    MessageBox.Show("Conexión no valida. Por favor, verifica la configuración.");
            //}
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            txtServidor.Text = "";
            txtBaseDatos.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtPuerto.Text = "";
            this.Show();
        }

        private void Conexion_Load(object sender, EventArgs e)
        {

        }
    }
}
