using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.util;
using Npgsql;

namespace LocadoraVeiculos.modelo
{
    public class usuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }


        public usuario()
        {

        }

        public usuario(int id, string username, string senha)
        {
            this.Id = id;
            this.Usuario = username;
            this.Senha = senha;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "INSERT INTO login (usuario, senha) values (@usuario, @senha)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@usuario", this.Usuario));
                cmd.Parameters.Add(new NpgsqlParameter("@senha", this.Senha));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }   // fim cadastrar

        public usuario Login()
        {
            //esses dados virão do banco de dados

            NpgsqlConnection npgsqlConnection = null;

            usuario objusuario = new usuario();
            try
            {

                npgsqlConnection = ConectaDB.getConexao();

                string sql = "";
                //monta o comando sql
                sql = "select * from login where usuario ='" + this.Usuario + "' and senha='" + this.Senha + "';";

                //atribui ao cmd o sql e a conexão a ser utilizada
                NpgsqlCommand cmd = new NpgsqlCommand(sql, npgsqlConnection);

                //exacuta-se o sql e declara um DataReader para receber a matriz de valores
                NpgsqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                objusuario.Id = Convert.ToInt32(dr["id"]);
                objusuario.Usuario = dr["usuario"].ToString();
                objusuario.Senha = dr["senha"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (npgsqlConnection != null)
                {
                    npgsqlConnection.Close();
                }
            }
            return objusuario;
        }
    }
}