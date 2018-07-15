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
    public partial class FormProcurarLivro : Form
    {
        DAL.ProcurarLivroMetodos procurarLivroMetodos = new DAL.ProcurarLivroMetodos();
        DAL.ProcurarLivro procurarLivro = new DAL.ProcurarLivro();

        public FormProcurarLivro()
        {
            InitializeComponent();
        }

        private void FormProcurarLivro_Load(object sender, EventArgs e)
        {
            dataGridViewProcurarLivro.DataSource = procurarLivroMetodos.SelecionarTodos();
        }

        private void setProcurarLivro()
        {
            procurarLivro.Titulo = textBoxTitulo.Text;
        }

        private Boolean validarCampos()
        {
            if (textBoxTitulo.Text == "")
            {
                errorProvider1.SetError(textBoxTitulo, "Campo obrigatório!");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBoxTitulo, "");
                return true;
            }
        }

        private void procurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarCampos() == true)
            {
                setProcurarLivro();

                dataGridViewProcurarLivro.DataSource = procurarLivroMetodos.ProcurarLivro(procurarLivro);
            }
        }

        private void limparCampoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxTitulo.Text = "";

            dataGridViewProcurarLivro.DataSource = procurarLivroMetodos.SelecionarTodos();
        }
    }
}
