using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LocadoraVeiculos.util;


namespace LocadoraVeiculos.modelo
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnh { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Pesquisa { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cnh, string endereco, string cidade, string cep)
        {
            this.Nome = nome;
            this.Cnh = cnh;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.Cep = cep;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "insert into cliente (nome, cnh, endereco, cidade, cep) values (@nome, @cnh, @endereco, @cidade, @cep)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@cnh", this.Cnh));
                cmd.Parameters.Add(new NpgsqlParameter("@endereco", this.Endereco));
                cmd.Parameters.Add(new NpgsqlParameter("@cidade", this.Cidade));
                cmd.Parameters.Add(new NpgsqlParameter("@cep", this.Cep));
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
        }

        public List<Cliente> Pesquisar()
        {
            List<Cliente> clientes = new List<Cliente>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from cliente where id=@id;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@id", Pesquisa));
                cmd.ExecuteNonQuery();

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Cliente novoCliente = new Cliente();
                    novoCliente.Id = int.Parse(dr["id"].ToString());
                    novoCliente.Nome = dr["nome"].ToString();
                    novoCliente.Cnh = dr["cnh"].ToString();
                    novoCliente.Endereco = dr["endereco"].ToString();
                    novoCliente.Cidade = dr["cidade"].ToString();
                    novoCliente.Cep = dr["cep"].ToString();

                    //add o objeto na lista
                    clientes.Add(novoCliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            return clientes;
        }

        public void Atualizar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "UPDATE CLIENTE SET  id=@id, nome=@nome, cnh=@cnh, endereco=@endereco, cidade=@cidade, cep=@cep";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from cliente;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Cliente novoCliente = new Cliente();
                    novoCliente.Id = int.Parse(dr["id"].ToString());
                    novoCliente.Nome = dr["nome"].ToString();
                    novoCliente.Cnh = dr["cnh"].ToString();
                    novoCliente.Endereco = dr["endereco"].ToString();
                    novoCliente.Cidade = dr["cidade"].ToString();
                    novoCliente.Cep = dr["cep"].ToString();

                    //add o objeto na lista
                    clientes.Add(novoCliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            return clientes;
        }
    }
}