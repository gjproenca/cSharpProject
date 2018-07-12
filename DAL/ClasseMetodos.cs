using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutorMetodos
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Editora;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void Inserir(Autor A)
        {

        }

        public void Alterar(Autor A)
        {

        }

        public void Eliminar(Autor A)
        {

        }

        public DataTable SelecionarTodos()
        {
            SqlDataAdapter comando = new SqlDataAdapter("SELECT IDAutor, Nome, PaisOrigem, PremioNobel, ResumoObra FROM Autores ORDER BY Nome ASC", conn);
            DataTable tabela = new DataTable();
            comando.Fill(tabela);
            return tabela;
        }
    }

    public class CategoriaMetodos
    {
        public void Inserir(Categoria C)
        {

        }

        public void Alterar(Categoria C)
        {

        }

        public void Eliminar(Categoria C)
        {

        }

        public DataTable SelecionarTodos(Categoria C)
        {
            return new DataTable();
        }
    }

    public class LivroMetodos
    {
        public void Inserir(Livro L)
        {

        }

        public void Alterar(Livro L)
        {

        }

        public void Eliminar(Livro L)
        {

        }

        public DataTable SelecionarTodos(Livro L)
        {
            return new DataTable();
        }
    }

    public class AutorLivroMetodos
    {
        public void Inserir(AutorLivro L)
        {

        }

        public void Alterar(AutorLivro L)
        {

        }

        public void Eliminar(AutorLivro L)
        {

        }

        public DataTable SelecionarTodos(AutorLivro L)
        {
            return new DataTable();
        }
    }
}
