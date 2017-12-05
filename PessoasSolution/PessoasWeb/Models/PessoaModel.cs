using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PessoasWeb.Models
{
    public class PessoaModel : ModelBase
    {
        [HttpPost]
        public void Create(Pessoa e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection; // objeto herdado do ModelBase
            cmd.CommandText = @"insert into pessoas values (@nome, @email, @senha, @dataNasc)";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@senha", e.Senha);
            DateTime data = Convert.ToDateTime(e.DataNascimento);
            cmd.Parameters.AddWithValue("@dataNasc", data);

            cmd.ExecuteNonQuery();

        }

        public Pessoa Read(string email, string senha)
        {
            Pessoa e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"exec Logar @email, @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                e = new Pessoa();
                //e.PessoaId = (int)reader["idPessoa"];
                e.Email = (string)reader["Email"];
                e.Senha = (string)reader["Senha"];
            }

            return e;
        }

        public List<Pessoa> Read()
        {
            List<Pessoa> lista = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from pessoas";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pessoa p = new Pessoa();
                p.PessoaId = (int)reader["id"];
                p.Nome = (string)reader["nome"];
                p.Email = (string)reader["email"];
                p.Senha = (string)reader["senha"];
                p.DataNascimento = (DateTime)reader["dataNas"];

                lista.Add(p);
            }

            return lista;
        }

        public void Update(Pessoa p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE pessoas set nome = @nome, email = @email, dataNasc = @dataNasc, where id = @id";

            cmd.Parameters.AddWithValue("@idUsuario", p.PessoaId);
            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@email", p.Email);
            //cmd.Parameters.AddWithValue("@senha", p.Senha);
            cmd.Parameters.AddWithValue("@dataNasc", p.DataNascimento);

            cmd.ExecuteNonQuery();
        }

        public void ChangePassowrd(int idPessoa, string pass, string newpass)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE pessoa set senha = @new where id = @id and senha = @atual";

            cmd.Parameters.AddWithValue("@idUsuario", idPessoa);
            cmd.Parameters.AddWithValue("@atual", pass);
            cmd.Parameters.AddWithValue("@new", newpass);

            cmd.ExecuteNonQuery();
        }


        public void Delete(int idPessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE from pessoas WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", idPessoa);

            cmd.ExecuteNonQuery();
        }

        public void UpdateImage(int idUsuario, string image)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE usuario set foto_perfil = @imagem where id = @id";

            cmd.Parameters.AddWithValue("@id", idUsuario);
            cmd.Parameters.AddWithValue("@imagem", image);

            cmd.ExecuteNonQuery();
        }
    }
}
