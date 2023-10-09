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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
            objetoSeries.mostrarSeries(dgvSeries);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaSerie formNuevaSerie = new NuevaSerie();
            formNuevaSerie.dgvSeries = dgvSeries;
            formNuevaSerie.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // verificar si hay al menos una fila en el DataGridView
            if (dgvSeries.Rows.Count > 0 && dgvSeries.CurrentRow != null)
            {
                string estado = dgvSeries.CurrentRow.Cells[8].Value.ToString();
                if (estado == "AN")
                {
                    MessageBox.Show("No se puede modificar una serie anulada");
                }
                else
                {
                    ModificarSerie formModificarSerie = new ModificarSerie();
                    formModificarSerie.dgvSeries = dgvSeries;
                    formModificarSerie.Show();
                }
            }
            else
            {
                MessageBox.Show("No hay registros para modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // verificar si hay al menos una fila en el DataGridView
            if (dgvSeries.Rows.Count > 0 && dgvSeries.CurrentRow != null)
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar la serie?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    string id = dgvSeries.CurrentRow.Cells[0].Value.ToString();

                    Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
                    objetoSeries.eliminarSeries(id);
                    objetoSeries.mostrarSeries(dgvSeries);
                }
            }
            else
            {
                MessageBox.Show("No hay registros para eliminar.");
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            // verificar si hay al menos una fila en el DataGridView
            if (dgvSeries.Rows.Count > 0 && dgvSeries.CurrentRow != null)
            {
                string estado = dgvSeries.CurrentRow.Cells[8].Value.ToString();
                if (estado == "AC")
                {
                    DialogResult resultado = MessageBox.Show("¿Deseas anular la serie?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (resultado == DialogResult.OK)
                    {
                        string id = dgvSeries.CurrentRow.Cells[0].Value.ToString();
                        estado = "AN";

                        Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
                        objetoSeries.anularSerie(id, estado);
                        objetoSeries.mostrarSeries(dgvSeries);
                    }
                }
                else
                {
                    MessageBox.Show("La serie se encuentra anulada");
                }
            }
            else
            {
                MessageBox.Show("No hay registros para anular");
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            Clases.ClassSeries objetoSeries = new Clases.ClassSeries();
            objetoSeries.mostrarSeries(dgvSeries);
        }
    }
}
