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
        private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");

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
            comm_insert.Parameters.AddWithValue("@paisOrigem", A.PaisOrigem);
            comm_insert.Parameters.AddWithValue("@premioNobel", A.PremioNobel);
            comm_insert.Parameters.AddWithValue("@resumoObra", A.ResumoObra);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_insert.ExecuteNonQuery();
            conn.Close();
        }

        public void Alterar(Autor A)
        {
            SqlCommand comm_update = new SqlCommand();
            comm_update.Connection = conn;
            comm_update.CommandType = CommandType.Text;
            comm_update.CommandText = "UPDATE Autores SET [Nome] = @nome, [PaisOrigem] = @paisOrigem," +
                "[PremioNobel] = @premioNobel, [ResumoObra] = @resumoObra WHERE [IDAutor] = @idAutor";
            //parâmetros do comando definido
            comm_update.Parameters.AddWithValue("@nome", A.Nome);
            comm_update.Parameters.AddWithValue("@paisOrigem", A.PaisOrigem);
            comm_update.Parameters.AddWithValue("@premioNobel", A.PremioNobel);
            comm_update.Parameters.AddWithValue("@resumoObra", A.ResumoObra);
            comm_update.Parameters.AddWithValue("@idAutor", A.IDAutor);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_update.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(Autor A)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM Autores WHERE [IDAutor] = @idAutor";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@idAutor", A.IDAutor);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarAutoresLivros(Autor A)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM AutoresLivros WHERE [Autor] = @idAutor";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@idAutor", A.IDAutor);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable SelecionarTodos()
        {
            SqlDataAdapter comando = new SqlDataAdapter("SELECT IDAutor, Nome, PaisOrigem, PremioNobel, ResumoObra FROM Autores ORDER BY Nome ASC", conn);
            DataTable tabela = new DataTable();
            comando.Fill(tabela);
            return tabela;
        }

        public int ContarLivros(Autor A)
        {
            SqlCommand comm_count = new SqlCommand();
            comm_count.Connection = conn;
            comm_count.CommandType = CommandType.Text;
            comm_count.CommandText = "SELECT COUNT(*) FROM AutoresLivros WHERE [Autor] = @idAutor";
            comm_count.Parameters.AddWithValue("@idAutor", A.IDAutor);

            conn.Open();
            int count = int.Parse(comm_count.ExecuteScalar().ToString());
            conn.Close();

            return count;
        }
    }

    public class CategoriaMetodos
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");

        public void Inserir(Categoria C)
        {
            SqlCommand comm_insert = new SqlCommand();
            comm_insert.Connection = conn;
            comm_insert.CommandType = CommandType.Text;
            comm_insert.CommandText = "INSERT INTO [Categorias]([Categoria], [Descricao]) VALUES(@categoria, @descricao)";
            //ler valores definidos no controlos TextBox e preencher
            //parâmetros do comando definido
            comm_insert.Parameters.AddWithValue("@categoria", C.NomeCategoria);
            comm_insert.Parameters.AddWithValue("@descricao", C.Descricao);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_insert.ExecuteNonQuery();
            conn.Close();
        }

        public void Alterar(Categoria C)
        {
            SqlCommand comm_update = new SqlCommand();
            comm_update.Connection = conn;
            comm_update.CommandType = CommandType.Text;
            comm_update.CommandText = "UPDATE Categorias SET [Categoria] = @categoria, [Descricao] = @descricao" +
                "WHERE [IDCategoria] = @idCategoria";
            //parâmetros do comando definido
            comm_update.Parameters.AddWithValue("@categoria", C.NomeCategoria);
            comm_update.Parameters.AddWithValue("@descricao", C.Descricao);
            comm_update.Parameters.AddWithValue("@idCategoria", C.IDCategoria);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_update.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(Categoria C)
        {

        }

        public DataTable SelecionarTodos()
        {
            SqlDataAdapter comando = new SqlDataAdapter("SELECT IDCategoria, Categoria, Descricao FROM Categorias ORDER BY Categoria ASC", conn);
            DataTable tabela = new DataTable();
            comando.Fill(tabela);
            return tabela;
        }

        public int ContarLivros(Categoria C)
        {
            SqlCommand comm_count = new SqlCommand();
            comm_count.Connection = conn;
            comm_count.CommandType = CommandType.Text;
            comm_count.CommandText = "SELECT COUNT(*) FROM Livros WHERE [Categoria] = @idCategoria";
            comm_count.Parameters.AddWithValue("@idCategoria", C.IDCategoria);

            conn.Open();
            int count = int.Parse(comm_count.ExecuteScalar().ToString());
            conn.Close();

            return count;
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
