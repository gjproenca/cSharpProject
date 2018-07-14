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

        private void preencherCampos()
        {
            textBoxCategoria.Text = dataGridViewCategorias.CurrentRow.Cells[1].Value.ToString();
            textBoxDescricao.Text = dataGridViewCategorias.CurrentRow.Cells[2].Value.ToString();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCategoria();

            categoriaMetodos.Inserir(categoria);

            dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
            preencherCampos();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja alterar esta categoria?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                setCategoria();

                categoriaMetodos.Alterar(categoria);

                dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                preencherCampos();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoriaMetodos.ContarLivros(categoria) > 0)
            {
                if (MessageBox.Show("Esta categoria tem outros registos associados, deseja apagar a categoria e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setCategoria();

                    categoriaMetodos.EliminarLivros(categoria);
                    categoriaMetodos.Eliminar(categoria);

                    dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
                    preencherCampos();
                }
            }
            else
            {
                if (MessageBox.Show("Tem a certeza que deseja eliminar esta categoria?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setCategoria();

                    categoriaMetodos.Eliminar(categoria);

                    dataGridViewCategorias.DataSource = categoriaMetodos.SelecionarTodos();
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

                if (c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }
    }
}
