using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // global variables declaration
        private FormLivros formLivros;
        private FormCategorias formCategorias;
        private FormAutores formAutores;

        private void livrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formLivros == null)
            {
                formLivros = new FormLivros();
                formLivros.MdiParent = this;
                formLivros.WindowState = FormWindowState.Maximized;
                formLivros.FormClosed += formLivrosClosed;
                formLivros.Show();
            }
            else
                formLivros.Activate();
        }

        private void formLivrosClosed(object sender, FormClosedEventArgs e)
        {
            formLivros = null;
            //throw new NotImplementedException();
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formCategorias == null)
            {
                formCategorias = new FormCategorias();
                formCategorias.MdiParent = this;
                formCategorias.WindowState = FormWindowState.Maximized;
                formCategorias.FormClosed += formCategoriasClosed;
                formCategorias.Show();
            }
            else
                formCategorias.Activate();
        }

        private void formCategoriasClosed(object sender, FormClosedEventArgs e)
        {
            formCategorias = null;
            //throw new NotImplementedException();
        }

        private void autoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formAutores == null)
            {
                formAutores = new FormAutores();
                formAutores.MdiParent = this;
                formAutores.WindowState = FormWindowState.Maximized;
                formAutores.FormClosed += formAutoresClosed;
                formAutores.Show();
            }
            else
                formAutores.Activate();
        }

        private void formAutoresClosed(object sender, FormClosedEventArgs e)
        {
            formAutores = null;
            //throw new NotImplementedException();
        }
    }
}
