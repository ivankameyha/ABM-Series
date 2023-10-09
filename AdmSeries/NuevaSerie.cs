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
    public partial class NuevaSerie : Form
    {
        public DataGridView dgvSeries { get; set; }
        public NuevaSerie()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // validacion de datos
            if (txtTitulo.Text == "" || txtDescripcion.Text == "" || txtEstrellas.Text == "" || cboGenero.Text == "" || txtPrecio.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Faltan datos por completar");
            }
            else
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";

                // true o false
                int atp = radioButton1.Checked ? 1 : 0;

                Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
                objetoSeries.guardarSeries(txtTitulo, txtDescripcion, dateTimePicker1, txtEstrellas, cboGenero, txtPrecio, atp, "AC");

                objetoSeries.mostrarSeries(dgvSeries);

                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // verifica si la tecla presionada es un numero o cualquier otro caracter
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // si no es un numero, se ignora
            }
        }
    }
}
