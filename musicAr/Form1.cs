using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicAr
{
    public partial class Form1 : Form
    {
        private List<Disco> listaDisco;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            listaDisco = negocio.listar();
            dgvDiscos.DataSource = listaDisco;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            cargarImagen(listaDisco[0].UrlImagenTapa);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuevoDiscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ventana de nuevo disco...");
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright 2023");
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDisco.Load(imagen);
            }
            catch (Exception)
            {
                pbxDisco.Load("https://upload.wikimedia.org/wikipedia/commons/d/d1/Image_not_available.png");
            }
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
        }
    }
}
