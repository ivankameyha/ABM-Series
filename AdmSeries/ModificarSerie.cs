using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace AdmSeries
{
    public partial class ModificarSerie : Form
    {
        public DataGridView dgvSeries { get; set; }
        public ModificarSerie()
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

                string id = dgvSeries.CurrentRow.Cells[0].Value.ToString();

                Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
                objetoSeries.modificarSeries(id, txtTitulo, txtDescripcion, dateTimePicker1, txtEstrellas, cboGenero, txtPrecio, atp, "AC");
                objetoSeries.mostrarSeries(dgvSeries);

                this.Close();
            }
        }

        private void ModificarSerie_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = dgvSeries.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvSeries.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dgvSeries.CurrentRow.Cells[3].Value.ToString();
            txtEstrellas.Text = dgvSeries.CurrentRow.Cells[4].Value.ToString();
            cboGenero.Text = dgvSeries.CurrentRow.Cells[5].Value.ToString();
            txtPrecio.Text = dgvSeries.CurrentRow.Cells[6].Value.ToString();
            radioButton1.Checked = Convert.ToBoolean(dgvSeries.CurrentRow.Cells[7].Value);
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
