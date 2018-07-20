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
    public partial class FormCategorias : Form
    {
        DAL.CategoriaMetodos categoriaMetodos = new DAL.CategoriaMetodos();
        DAL.Categoria categoria = new DAL.Categoria();

        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
            preencherCampos();
            setCategoria();
        }

        private void FormCategorias_Activated(object sender, EventArgs e)
        {
            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
            preencherCampos();
            setCategoria();
        }

        private void dataGridViewCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherCampos();
            setCategoria();
        }

        private void setCategoria()
        {
            categoria.IDCategoria = int.Parse(dataGridViewCategorias.CurrentRow.Cells[0].Value.ToString());
            categoria.NomeCategoria = textBoxCategoria.Text;
            categoria.Descricao = textBoxDescricao.Text;
        }

        private Boolean validarCampos()
        {
            if (textBoxCategoria.Text == "")
            {
                errorProvider1.SetError(textBoxCategoria, "Campo obrigatório!");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBoxCategoria, "");
                return true;
            }
        }

        private void preencherCampos()
        {
            textBoxCategoria.Text = dataGridViewCategorias.CurrentRow.Cells[1].Value.ToString();
            textBoxDescricao.Text = dataGridViewCategorias.CurrentRow.Cells[2].Value.ToString();
        }

        private Boolean verificarSemCategoria()
        {
            if (textBoxCategoria.Text == "Sem categoria")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCategoria();

            if (validarCampos() == true)
            {
                if (categoriaMetodos.verificarDuplicado(categoria) > 0)
                {
                    MessageBox.Show("Esta categoria já existe!", "Erro!", MessageBoxButtons.OK);
                }
                else
                {
                    categoriaMetodos.Inserir(categoria);

                    dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                    preencherCampos();
                }
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCategoria();

            if (verificarSemCategoria() == true)
            {
                if (validarCampos() == true)
                {
                    if (categoriaMetodos.verificarDuplicado(categoria) > 0)
                    {
                        MessageBox.Show("Esta categoria já existe!", "Erro!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MessageBox.Show("Tem a certeza que deseja alterar esta categoria?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            categoriaMetodos.Alterar(categoria);

                            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                            preencherCampos();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é possível alterar esta categoria, esta categoria pertence ao programa!", "Erro!", MessageBoxButtons.OK);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCategoria();

            if (verificarSemCategoria() == true)
            {
                if (categoriaMetodos.ContarLivros(categoria) > 0)
                {
                    if (MessageBox.Show("Esta categoria tem outros registos associados, deseja apagar a categoria e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // FIXME: not able to delete books with entries in autores livros, might need to delete author aswell
                        categoriaMetodos.AlterarCategoriaLivros(categoria);
                        categoriaMetodos.Eliminar(categoria);

                        dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                        preencherCampos();
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem a certeza que deseja eliminar esta categoria?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        categoriaMetodos.Eliminar(categoria);

                        dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                        preencherCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é possível eliminar esta categoria, esta categoria pertence ao programa!", "Erro!", MessageBoxButtons.OK);
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

                if (c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }
    }
}
