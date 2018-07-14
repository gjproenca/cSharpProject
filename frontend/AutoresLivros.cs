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
    public partial class AutoresLivros : Form
    {
        DAL.AutorLivroMetodos autorLivroMetodos = new DAL.AutorLivroMetodos();
        DAL.AutorLivro autorLivro = new DAL.AutorLivro();

        public AutoresLivros()
        {
            InitializeComponent();
        }

        private void AutoresLivros_Load(object sender, EventArgs e)
        {
            dataGridViewAutoresLivros.DataSource = autorLivroMetodos.SelecionarTodos();
        }
    }
}
