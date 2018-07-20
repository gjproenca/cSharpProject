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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            DAL.CategoriaMetodos categoriaMetodos = new DAL.CategoriaMetodos();

            categoriaMetodos.InserirSemCategoria();
        }

        // global variables declaration
        private FormLivros formLivros;
        private FormAutores formAutores;
        private FormCategorias formCategorias;
        private FormAutoresLivros formAutoresLivros;
        private FormProcurarLivro formProcurarLivro;

        // livros
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
            {
                formLivros.WindowState = FormWindowState.Maximized;
                formLivros.Activate();
            }
        }

        private void formLivrosClosed(object sender, FormClosedEventArgs e)
        {
            formLivros = null;
        }

        // autoreslivros
        private void autoresLivrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formAutoresLivros == null)
            {
                formAutoresLivros = new FormAutoresLivros();
                formAutoresLivros.MdiParent = this;
                formAutoresLivros.WindowState = FormWindowState.Maximized;
                formAutoresLivros.FormClosed += formAutoresLivrosClosed;
                formAutoresLivros.Show();
            }
            else
            {
                formAutoresLivros.WindowState = FormWindowState.Maximized;
                formAutoresLivros.Activate();
            }
        }

        private void formAutoresLivrosClosed(object sender, FormClosedEventArgs e)
        {
            formAutoresLivros = null;
        }

        // autores
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
            {
                formAutores.WindowState = FormWindowState.Maximized;
                formAutores.Activate();
            }
        }

        private void formAutoresClosed(object sender, FormClosedEventArgs e)
        {
            formAutores = null;
        }

        // categorias
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
            {
                formCategorias.WindowState = FormWindowState.Maximized;
                formCategorias.Activate();
            }
        }

        private void formCategoriasClosed(object sender, FormClosedEventArgs e)
        {
            formCategorias = null;
        }

        private void procurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formProcurarLivro == null)
            {
                formProcurarLivro = new FormProcurarLivro();
                formProcurarLivro.MdiParent = this;
                formProcurarLivro.WindowState = FormWindowState.Maximized;
                formProcurarLivro.FormClosed += formProcurarLivroClosed;
                formProcurarLivro.Show();
            }
            else
            {
                formProcurarLivro.WindowState = FormWindowState.Maximized;
                formProcurarLivro.Activate();
            }
        }

        private void formProcurarLivroClosed(object sender, FormClosedEventArgs e)
        {
            formCategorias = null;
        }
    }
}
