using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LocadoraVeiculos.util;
using LocadoraVeiculos.modelo;
using LocadoraVeiculos.Properties;


namespace LocadoraVeiculos.modelo
{
    //Veiculo
    class Veiculo
    {
        public int Id { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Pesquisa { get; set; }

        public Veiculo()
        {

        }

        public Veiculo(string fabricante, string modelo, int ano, string placa)
        {
            this.Fabricante = fabricante;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Placa = placa;
        }

        //Cadastrar
        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "insert into veiculo (fabricante, modelo, ano, placa) values (@fabricante, @modelo, @ano, @placa)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);


                cmd.Parameters.Add(new NpgsqlParameter("@fabricante", this.Fabricante));
                cmd.Parameters.Add(new NpgsqlParameter("@modelo", this.Modelo));
                cmd.Parameters.Add(new NpgsqlParameter("@ano", this.Ano));
                cmd.Parameters.Add(new NpgsqlParameter("@placa", this.Placa));  
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
        public List<Veiculo> Pesquisar()
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from veiculo where id=@id;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@id", Pesquisa));
                cmd.ExecuteNonQuery();

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Veiculo novoVeiculo = new Veiculo();
                    novoVeiculo.Id = int.Parse(dr["id"].ToString());
                    novoVeiculo.Fabricante = dr["fabricante"].ToString();
                    novoVeiculo.Modelo = dr["modelo"].ToString();
                    novoVeiculo.Ano = int.Parse(dr["ano"].ToString());
                    novoVeiculo.Placa = dr["placa"].ToString();

                    //add o objeto na lista
                    veiculos.Add(novoVeiculo);
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
            return veiculos;
        } // fim pesquisar

        //Atualizar
        public void Atualizar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "UPDATE CLIENTE SET  id=@id, fabricante=@fabricante, modelo=@modelo, ano=@ano, placa=@placa";
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
        public List<Veiculo> Listar()
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "select * from veiculo;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                //executa a consulta e acumula o resultado em uma tabela virtual
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                //List<Cliente> listaClientes = new List<Cliente>();
                while (dr.Read())
                {
                    Veiculo novoVeiculo = new Veiculo();
                    novoVeiculo.Id = int.Parse(dr["id"].ToString());
                    novoVeiculo.Fabricante = dr["fabricante"].ToString();
                    novoVeiculo.Modelo = dr["modelo"].ToString();
                    novoVeiculo.Ano = int.Parse(dr["ano"].ToString());
                    novoVeiculo.Placa = dr["placa"].ToString();

                    //add o objeto na lista
                    veiculos.Add(novoVeiculo);
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
            return veiculos;
        }   //fim Listar
    }   //fim Veiculo
}
