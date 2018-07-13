using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class FormAutores : Form
    {
        DAL.AutorMetodos autorMetodos = new DAL.AutorMetodos();
        DAL.Autor autor = new DAL.Autor();

        public FormAutores()
        {
            InitializeComponent();
        }

        private void FormAutores_Load(object sender, EventArgs e)
        {
            dataGridViewAutores.DataSource = autorMetodos.SelecionarTodos();
            PreencherPaises();
        }

        private void dataGridViewAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNome.Text = dataGridViewAutores.CurrentRow.Cells[1].Value.ToString();
            comboBoxPaises.SelectedItem = dataGridViewAutores.CurrentRow.Cells[2].Value.ToString();
            checkBoxNobel.Checked = Convert.ToBoolean(dataGridViewAutores.CurrentRow.Cells[3].Value);
            textBoxResumoObra.Text = dataGridViewAutores.CurrentRow.Cells[4].Value.ToString();
        }

        public void limpar()
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

        #region Paises
        void PreencherPaises()
        {
            WebRequest req;
            req = WebRequest.Create("https://restcountries.eu/rest/v2/all");
            req.ContentType = "application/json";
            WebResponse resp = req.GetResponse();
            Stream strm = resp.GetResponseStream();
            StreamReader strm_reader = new StreamReader(strm);
            string json = strm_reader.ReadToEnd();
            List<Pais> paises = JsonConvert.DeserializeObject<List<Pais>>(json);
            foreach (Pais p in paises)
            {
                comboBoxPaises.Items.Add(p.name);
            }
        }

        public class Currency
        {
            public string code { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
        }

        public class Language
        {
            public string iso639_1 { get; set; }
            public string iso639_2 { get; set; }
            public string name { get; set; }
            public string nativeName { get; set; }
        }

        public class Translations
        {
            public string de { get; set; }
            public string es { get; set; }
            public string fr { get; set; }
            public string ja { get; set; }
            public string it { get; set; }
            public string br { get; set; }
            public string pt { get; set; }
            public string nl { get; set; }
            public string hr { get; set; }
            public string fa { get; set; }
        }

        public class Pais
        {
            public string name { get; set; }
            public List<string> topLevelDomain { get; set; }
            public string alpha2Code { get; set; }
            public string alpha3Code { get; set; }
            public List<string> callingCodes { get; set; }
            public string capital { get; set; }
            public List<object> altSpellings { get; set; }
            public string region { get; set; }
            public string subregion { get; set; }
            public int population { get; set; }
            public List<object> latlng { get; set; }
            public string demonym { get; set; }
            public double? area { get; set; }
            public double? gini { get; set; }
            public List<string> timezones { get; set; }
            public List<object> borders { get; set; }
            public string nativeName { get; set; }
            public string numericCode { get; set; }
            public List<Currency> currencies { get; set; }
            public List<Language> languages { get; set; }
            public Translations translations { get; set; }
            public string flag { get; set; }
            public List<object> regionalBlocs { get; set; }
            public string cioc { get; set; }
        }
        #endregion

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autor.Nome = textBoxNome.Text;
            autor.PremioNobel = checkBoxNobel.Checked;
            autor.ResumoObra = textBoxResumoObra.Text;
            autor.PaisOrigem = comboBoxPaises.Text;

            autorMetodos.Inserir(autor);

            dataGridViewAutores.DataSource = autorMetodos.SelecionarTodos();

            limpar();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autor.IDAutor = int.Parse(dataGridViewAutores.CurrentRow.Cells[0].Value.ToString());
            autor.Nome = textBoxNome.Text;
            autor.PremioNobel = checkBoxNobel.Checked;
            autor.ResumoObra = textBoxResumoObra.Text;
            autor.PaisOrigem = comboBoxPaises.Text;

            if (MessageBox.Show("Tem a certeza que deseja alterar este autor?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                autorMetodos.Alterar(autor);
            }

            dataGridViewAutores.DataSource = autorMetodos.SelecionarTodos();

            limpar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autor.IDAutor = int.Parse(dataGridViewAutores.CurrentRow.Cells[0].Value.ToString());

            if (autorMetodos.ContarLivros(autor) > 0)
            {
                if (MessageBox.Show("Este autor tem outros registos associados, deseja apagar o autor e todos os registos associados?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    autorMetodos.EliminarAutoresLivros(autor);
                    autorMetodos.Eliminar(autor);
                }
            }
            else
            {
                if (MessageBox.Show("Tem a certeza que deseja eliminar este autor?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    autorMetodos.Eliminar(autor);
                }
            }

            dataGridViewAutores.DataSource = autorMetodos.SelecionarTodos();

            limpar();
        }
    }
}
