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
        DAL.AutorMetodos AutorM = new DAL.AutorMetodos();

        public FormAutores()
        {
            InitializeComponent();
        }

        private void FormAutores_Load(object sender, EventArgs e)
        {
            dataGridViewAutores.DataSource = AutorM.SelecionarTodos();
            PreencherPaises();
        }

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
    }
}
