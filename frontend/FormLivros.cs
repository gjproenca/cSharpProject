using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class FormLivros : Form
    {
        DAL.LivroMetodos livroMetodos = new DAL.LivroMetodos();
        DAL.Livro livro = new DAL.Livro();

        public FormLivros()
        {
            InitializeComponent();
        }

        private void FormLivros_Load(object sender, EventArgs e)
        {
            dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
            preencherCampos();
            setLivro();
        }

        private void dataGridViewLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherCampos();
            setLivro();
        }

        private void preencherCampos()
        {
            textBoxTitulo.Text = dataGridViewLivros.CurrentRow.Cells[1].Value.ToString();
            textBoxIsbn.Text = dataGridViewLivros.CurrentRow.Cells[2].Value.ToString();

            comboBoxCategoria.DataSource = livroMetodos.SelecionarCategorias();
            comboBoxCategoria.DisplayMember = "Categoria";
            comboBoxCategoria.ValueMember = "Categoria";

            comboBoxCategoria.Text = dataGridViewLivros.CurrentRow.Cells[3].Value.ToString();
            textBoxAnoLancamento.Text = dataGridViewLivros.CurrentRow.Cells[4].Value.ToString();
            textBoxPreco.Text = dataGridViewLivros.CurrentRow.Cells[5].Value.ToString();
            textBoxQuantidadeStock.Text = dataGridViewLivros.CurrentRow.Cells[6].Value.ToString();
        }

        private void setLivro()
        {
            // TODO: validations
            livro.IDLivro = int.Parse(dataGridViewLivros.CurrentRow.Cells[0].Value.ToString());
            livro.Titulo = textBoxTitulo.Text;
            livro.ISBN = textBoxIsbn.Text;
            livro.Categoria = comboBoxCategoria.Text;

            int.TryParse(textBoxAnoLancamento.Text, out int AnoLancamento);
            livro.AnoLancamento = AnoLancamento;

            decimal.TryParse(textBoxPreco.Text, out decimal preco);
            livro.Preco = preco;

            int.TryParse(textBoxQuantidadeStock.Text, out int quantidadeStock);
            livro.QuantidadeStock = quantidadeStock;
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLivro();

            livroMetodos.Inserir(livro);

            dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
            preencherCampos();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja alterar este livro?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                setLivro();
                livroMetodos.Alterar(livro);

                dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
                preencherCampos();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (livroMetodos.ContarAutoresLivros(livro) > 0)
            {
                if (MessageBox.Show("Este livro tem outros registos associados, deseja apagar o livro e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setLivro();

                    livroMetodos.EliminarAutoresLivros(livro);
                    livroMetodos.Eliminar(livro);

                    dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
                    preencherCampos();
                }
            }
            else
            {
                if (MessageBox.Show("Tem a certeza que deseja eliminar este livro?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setLivro();

                    livroMetodos.Eliminar(livro);

                    dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
                    preencherCampos();
                }
            }
        }

        private void limparCamposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }

                if (c is CheckBox)
                {
                    // TODO: checkbox clear
                }

                if (c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }
    }
}
