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
        //Other pcs
        //private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");
        //My pc
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Editora;Integrated Security=True");

        public void Inserir(Autor A)
        {
            SqlCommand comm_insert = new SqlCommand();
            comm_insert.Connection = conn;
            comm_insert.CommandType = CommandType.Text;
            comm_insert.CommandText = "INSERT INTO [Autores]([Nome], [PaisOrigem], [PremioNobel], [ResumoObra]) VALUES(@nome, @paisOrigem," +
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
            comm_update.CommandText = "UPDATE Autores SET [Nome] = @nome, [PaisOrigem] = @paisOrigem, [PremioNobel] = @premioNobel, [ResumoObra] = @resumoObra WHERE [IDAutor] = @idAutor";
            //parâmetros do comando definido
            comm_update.Parameters.AddWithValue("@nome", A.Nome);
            comm_update.Parameters.AddWithValue("@paisOrigem", A.PaisOrigem);
            comm_update.Parameters.AddWithValue("@premioNobel", A.PremioNobel);
            comm_update.Parameters.AddWithValue("@resumoObra", A.ResumoObra);
            comm_update.Parameters.AddWithValue("@idAutor", A.IDAutor);
            //abrir ligação à base de dados e executar UPDATE
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
            //abrir ligação à base de dados e executar DELETE
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
            //abrir ligação à base de dados e executar DELETE
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
        //Other pcs
        //private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");
        //My pc
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Editora;Integrated Security=True");

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
            comm_update.CommandText = "UPDATE Categorias SET Categoria = @categoria, Descricao = @descricao WHERE [IDCategoria] = @idCategoria";
            //parâmetros do comando definido
            comm_update.Parameters.AddWithValue("@categoria", C.NomeCategoria);
            comm_update.Parameters.AddWithValue("@descricao", C.Descricao);
            comm_update.Parameters.AddWithValue("@idCategoria", C.IDCategoria);
            //abrir ligação à base de dados e executar UPDATE
            conn.Open();
            comm_update.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(Categoria C)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM Categorias WHERE [IDCategoria] = @idCategoria";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@idCategoria", C.IDCategoria);
            //abrir ligação à base de dados e executar DELETE
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarLivros(Categoria C)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM Livros WHERE [Categoria] = @categoria";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@categoria", C.IDCategoria);
            //abrir ligação à base de dados e executar DELETE
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
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
        //Other pcs
        //private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");
        //My pc
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Editora;Integrated Security=True");

        public void Inserir(Livro L)
        {
            SqlCommand comm_insert = new SqlCommand();
            comm_insert.Connection = conn;
            comm_insert.CommandType = CommandType.Text;
            comm_insert.CommandText = "INSERT INTO [Livros]([Titulo], [ISBN], [Categoria], [AnoLancamento], [Preco], [QuantidadeStock]) VALUES(@titulo, @isbn, (SELECT IDCategoria FROM Categorias WHERE Categoria = @categoria), @anoLancamento, @preco, @quantidadeStock)";
            //ler valores definidos no controlos TextBox e preencher
            //parâmetros do comando definido
            comm_insert.Parameters.AddWithValue("@titulo", L.Titulo);
            comm_insert.Parameters.AddWithValue("@isbn", L.ISBN);
            comm_insert.Parameters.AddWithValue("@categoria", L.Categoria);
            comm_insert.Parameters.AddWithValue("@anoLancamento", L.AnoLancamento);
            comm_insert.Parameters.AddWithValue("@preco", L.Preco);
            comm_insert.Parameters.AddWithValue("@quantidadeStock", L.QuantidadeStock);
            //abrir ligação à base de dados e executar INSERT
            conn.Open();
            comm_insert.ExecuteNonQuery();
            conn.Close();
        }

        public void Alterar(Livro L)
        {
            SqlCommand comm_update = new SqlCommand();
            comm_update.Connection = conn;
            comm_update.CommandType = CommandType.Text;
            comm_update.CommandText = "UPDATE Livros SET Titulo= @titulo, ISBN = @isbn, Categoria = (SELECT IDCategoria FROM Categorias WHERE Categoria = @categoria), AnoLancamento = @anoLancamento, Preco = @preco, QuantidadeStock = @quantidadeStock WHERE [IDLivro] = @idLivro";
            //parâmetros do comando definido
            comm_update.Parameters.AddWithValue("@titulo", L.Titulo);
            comm_update.Parameters.AddWithValue("@isbn", L.ISBN);
            comm_update.Parameters.AddWithValue("@categoria", L.Categoria);
            comm_update.Parameters.AddWithValue("@anoLancamento", L.AnoLancamento);
            comm_update.Parameters.AddWithValue("@preco", L.Preco);
            comm_update.Parameters.AddWithValue("@quantidadeStock", L.QuantidadeStock);
            comm_update.Parameters.AddWithValue("@idLivro", L.IDLivro);
            //abrir ligação à base de dados e executar UPDATE
            conn.Open();
            comm_update.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(Livro L)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM Livros WHERE IDLivro = @idLivro";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@idLivro", L.IDLivro);
            //abrir ligação à base de dados e executar DELETE
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarAutoresLivros(Livro L)
        {
            SqlCommand comm_delete = new SqlCommand();
            comm_delete.Connection = conn;
            comm_delete.CommandType = CommandType.Text;
            comm_delete.CommandText = "DELETE FROM AutoresLivros WHERE Livro = @livro";
            //parâmetros do comando definido
            comm_delete.Parameters.AddWithValue("@livro", L.IDLivro);
            //abrir ligação à base de dados e executar DELETE
            conn.Open();
            comm_delete.ExecuteNonQuery();
            conn.Close();
        }

        public int ContarAutoresLivros(Livro L)
        {
            SqlCommand comm_count = new SqlCommand();
            comm_count.Connection = conn;
            comm_count.CommandType = CommandType.Text;
            comm_count.CommandText = "SELECT COUNT(*) FROM AutoresLivros WHERE [Livro] = @idLivro";
            comm_count.Parameters.AddWithValue("@idLivro", L.IDLivro);

            conn.Open();
            int count = int.Parse(comm_count.ExecuteScalar().ToString());
            conn.Close();

            return count;
        }

        public DataTable SelecionarCategorias()
        {
            SqlDataAdapter comando = new SqlDataAdapter("SELECT DISTINCT Categoria FROM Categorias", conn);
            DataTable tabela = new DataTable();
            comando.Fill(tabela);
            return tabela;
        }

        public DataTable SelecionarTodos()
        {
            SqlDataAdapter comando = new SqlDataAdapter("SELECT L.IDLivro, L.Titulo, L.ISBN, C.Categoria, L.AnoLancamento, L.Preco, L.QuantidadeStock FROM Livros L JOIN Categorias C  ON L.Categoria = C.IDCategoria ORDER BY Titulo ASC", conn);
            DataTable tabela = new DataTable();
            comando.Fill(tabela);
            return tabela;
        }
    }

    public class AutorLivroMetodos
    {
        //Other pcs
        //private SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Editora;Integrated Security=True");
        //My pc
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Editora;Integrated Security=True");

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
