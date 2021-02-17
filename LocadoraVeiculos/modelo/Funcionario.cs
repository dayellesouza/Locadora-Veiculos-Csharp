using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LocadoraVeiculos.util;

namespace LocadoraVeiculos.modelo
{
    class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public float Salario { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Pesquisa { get; set; }


        public Funcionario()
        {

        }

        public Funcionario(string nome, string cargo, int salario, string endereco, string cidade, string cep)
        {
            this.Nome = nome;
            this.Cargo = cargo;
            this.Salario = salario;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.Cep = cep;
        }

        //Cadastrar
        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "insert into funcionario (nome, cargo, salario, endereco, cidade, cep) values (@nome, @cargo, @salario, @endereco, @cidade, @cep)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@cargo", this.Cargo));
                cmd.Parameters.Add(new NpgsqlParameter("@salario", this.Salario));
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

        }   //fim cadastrar

        //Pesquisar
        public List<Funcionario> Pesquisar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from funcionario where id=@id;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@id", Pesquisa));
                cmd.ExecuteNonQuery();

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Funcionario novoFuncionario = new Funcionario();
                    novoFuncionario.Id = int.Parse(dr["id"].ToString());
                    novoFuncionario.Nome = dr["nome"].ToString();
                    novoFuncionario.Cargo = dr["cargo"].ToString();
                    novoFuncionario.Salario = float.Parse(dr["salario"].ToString());
                    novoFuncionario.Endereco = dr["endereco"].ToString();
                    novoFuncionario.Cidade = dr["cidade"].ToString();
                    novoFuncionario.Cep = dr["cep"].ToString();

                    //add o objeto na lista
                    funcionarios.Add(novoFuncionario);
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
            return funcionarios;
        } // fim pesquisar

        //Atualizar
        public void Atualizar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "UPDATE CLIENTE SET  id=@id, nome=@nome, cargo=@cargo, salario=@salario, endereco=@endereco, cidade=@cidade, cep=@cep";
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
        }   //fim Atualizar

        //Listar
        public List<Funcionario> Listar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from funcionario;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Funcionario novoFuncionario = new Funcionario();
                    novoFuncionario.Id = int.Parse(dr["id"].ToString());
                    novoFuncionario.Nome = dr["nome"].ToString();
                    novoFuncionario.Cargo = dr["cargo"].ToString();
                    novoFuncionario.Salario = float.Parse(dr["salario"].ToString());
                    novoFuncionario.Endereco = dr["endereco"].ToString();
                    novoFuncionario.Cidade = dr["cidade"].ToString();
                    novoFuncionario.Cep = dr["cep"].ToString();

                    //add o objeto na lista
                    funcionarios.Add(novoFuncionario);
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
            return funcionarios;
        }   //fim Listar
    }
}
