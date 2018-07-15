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
    public partial class FormAutoresLivros : Form
    {
        DAL.AutorLivroMetodos autorLivroMetodos = new DAL.AutorLivroMetodos();
        DAL.AutorLivro autorLivro = new DAL.AutorLivro();

        public FormAutoresLivros()
        {
            InitializeComponent();
        }

        private void AutoresLivros_Load(object sender, EventArgs e)
        {
            dataGridViewAutoresLivros.DataSource = autorLivroMetodos.SelecionarTodos();
            preencherCampos();
            setAutorLivro();
        }

        private void dataGridViewAutoresLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherCampos();
            setAutorLivro();
        }

        private void preencherCampos()
        {
            comboBoxAutor.DataSource = autorLivroMetodos.SelecionarAutores();
            comboBoxAutor.DisplayMember = "Nome";
            comboBoxAutor.DisplayMember = "Categoria";
            comboBoxAutor.Text = dataGridViewAutoresLivros.CurrentRow.Cells[1].Value.ToString();

            comboBoxLivro.DataSource = autorLivroMetodos.SelecionarLivros();
            comboBoxLivro.DisplayMember = "Titulo";
            comboBoxLivro.ValueMember = "Titulo";
            comboBoxLivro.Text = dataGridViewAutoresLivros.CurrentRow.Cells[2].Value.ToString();
        }

        private void setAutorLivro()
        {
            autorLivro.IDAutorLivro = int.Parse(dataGridViewAutoresLivros.CurrentRow.Cells[0].Value.ToString());
            autorLivro.Autor = comboBoxAutor.Text;
            autorLivro.Livro = comboBoxLivro.Text;
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setAutorLivro();
            autorLivroMetodos.Inserir(autorLivro);

            dataGridViewAutoresLivros.DataSource = autorLivroMetodos.SelecionarTodos();
            preencherCampos();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja alterar este registo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                setAutorLivro();
                autorLivroMetodos.Alterar(autorLivro);

                dataGridViewAutoresLivros.DataSource = autorLivroMetodos.SelecionarTodos();
                preencherCampos();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja eliminar este registo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                setAutorLivro();
                autorLivroMetodos.Eliminar(autorLivro);

                dataGridViewAutoresLivros.DataSource = autorLivroMetodos.SelecionarTodos();
                preencherCampos();
            }
        }

        private void limparCamposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxAutor.SelectedIndex = 0;
            comboBoxLivro.SelectedIndex = 0;
        }
    }
}
