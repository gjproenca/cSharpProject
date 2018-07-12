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
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Editora;Integrated Security=True");

        public void Inserir(Autor A)
        {
            SqlCommand comm_insert = new SqlCommand();
            comm_insert.Connection = conn;
            comm_insert.CommandType = CommandType.Text;
            comm_insert.CommandText = "INSERT INTO [Autores]([Nome], [PaisOrigem]," +
                "[PremioNobel], [ResumoObra]) VALUES(@nome, @paisOrigem," +
                "@premioNobel, @resumoObra)";
            //ler valores definidos no controlos TextBox e preencher
            //parâmetros do comando definido
            comm_insert.Parameters.AddWithValue("@nome", A.Nome);
            comm_insert.Parameters.AddWithValue("@paisOrigem",  A.PaisOrigem);
            comm_insert.Parameters.AddWithValue("@premioNobel", A.PremioNobel);
            comm_insert.Parameters.AddWithValue("@resumoObra", A.ResumoObra);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_insert.ExecuteNonQuery();
            conn.Close();
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
