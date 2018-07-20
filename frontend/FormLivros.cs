using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void FormLivros_Activated(object sender, EventArgs e)
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

        private Boolean validarCampos()
        {
            Boolean validarTitulo = false;
            Boolean validarIsbn = false;
            Boolean validarAno = false;
            Boolean validarPreco = false;
            Boolean validarQuantidadeStock = false;

            Regex validar = new Regex("(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})");

            if (textBoxTitulo.Text == "")
            {
                errorProvider1.SetError(textBoxTitulo, "Campo obrigatório!");
            }
            else
            {
                errorProvider1.SetError(textBoxTitulo, "");
                validarTitulo = true;
            }

            if (textBoxIsbn.Text == "")
            {
                errorProvider1.SetError(textBoxIsbn, "Campo obrigatório!");
            }
            else if (validar.IsMatch(textBoxIsbn.Text) == false)
            {
                errorProvider1.SetError(textBoxIsbn, "Formato inválido!");
            }
            else
            {
                errorProvider1.SetError(textBoxIsbn, "");
                validarIsbn = true;
            }

            if (Decimal.TryParse(textBoxAnoLancamento.Text, out decimal tempAno) == false)
            {
                errorProvider1.SetError(textBoxAnoLancamento, "Formato inválido!");
            }
            else
            {
                errorProvider1.SetError(textBoxAnoLancamento, "");
                validarAno = true;
            }

            if (textBoxPreco.Text == "")
            {
                errorProvider1.SetError(textBoxPreco, "Campo obrigatório!");
            }
            else if (Decimal.TryParse(textBoxPreco.Text, out decimal tempPreco) == false)
            {
                errorProvider1.SetError(textBoxPreco, "Formato inválido!");
            }
            else if (tempPreco <= 0)
            {
                errorProvider1.SetError(textBoxPreco, "O preço tem de ser superior a zero!");
            }
            else
            {
                errorProvider1.SetError(textBoxPreco, "");
                validarPreco = true;
            }

            if (textBoxQuantidadeStock.Text == "")
            {
                errorProvider1.SetError(textBoxQuantidadeStock, "Campo obrigatório!");
            }
            else if (int.TryParse(textBoxQuantidadeStock.Text, out int tempQuantidadeStock) == false)
            {
                errorProvider1.SetError(textBoxQuantidadeStock, "Formato inválido!");
            }
            else if (tempQuantidadeStock < 0)
            {
                errorProvider1.SetError(textBoxQuantidadeStock, "A quantidade de stock tem de ser igual ou superior a zero!");
            }
            else
            {
                errorProvider1.SetError(textBoxQuantidadeStock, "");
                validarQuantidadeStock = true;
            }

            if (validarTitulo == true && validarIsbn == true && validarAno == true && validarPreco == true && validarQuantidadeStock == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLivro();

            if (validarCampos() == true)
            {
                if (livroMetodos.verificarDuplicado(livro) > 0)
                {
                    MessageBox.Show("Este livro já existe!", "Erro!", MessageBoxButtons.OK);
                }
                else
                {
                    livroMetodos.Inserir(livro);

                    dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
                    preencherCampos();
                }
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLivro();

            if (validarCampos() == true)
            {
                if (livroMetodos.verificarDuplicado(livro) > 0)
                {
                    MessageBox.Show("Este livro já existe!", "Erro!", MessageBoxButtons.OK);
                }
                else
                {
                    if (MessageBox.Show("Tem a certeza que deseja alterar este livro?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        livroMetodos.Alterar(livro);

                        dataGridViewLivros.DataSource = livroMetodos.SelecionarTodos();
                        preencherCampos();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLivro();
            if (livroMetodos.ContarAutoresLivros(livro) > 0)
            {
                if (MessageBox.Show("Este livro tem outros registos associados, deseja apagar o livro e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
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
            }

            comboBoxCategoria.SelectedIndex = 0;
        }
    }
}
