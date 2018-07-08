using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Autor
    {
        public int IDAutor { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public bool PremioNobel { get; set; }
        public string ResumoObra { get; set; }
    }

    public class AutoresLivros
    {
        public int IDAutorLivro { get; set; }
        public int Autor { get; set; }
        public int Livro { get; set; }
    }

    public class Livros
    {
        public int IDLivro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int Categoria { get; set; }
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeStock { get; set; }
    }

    public class Categorias
    {
        public int IDCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
    }
}
