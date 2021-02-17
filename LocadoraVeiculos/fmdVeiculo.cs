using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using LocadoraVeiculos.util;
using LocadoraVeiculos.modelo;

namespace LocadoraVeiculos
{
    public partial class fmdVeiculo : Form
    {
        List<Veiculo> listaVeiculos = new List<Veiculo>();
        public fmdVeiculo()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------//
        //Veículo

        
        

        //prencher dgv
        private void preencherDataGridView1()
        {
            dgvVeiculo.Rows.Clear();

            for (int i = 0; i < listaVeiculos.Count; i++)
            {
                string[] nova_linha = new string[]
                {
                    listaVeiculos[i].Fabricante,
                    listaVeiculos[i].Modelo,
                    listaVeiculos[i].Ano.ToString(),
                    listaVeiculos[i].Placa,
                };

                dgvVeiculo.Rows.Add(nova_linha);
            }

        } //fim preencher dgv

        
        private void limpaCampos1()
        {
            txtFabricante.Clear();
            txtModelo.Clear();
            txtAno.Clear();
            mtxtPlaca.Clear();
            txtBusca1.Clear();
        }

        private void dgvVeiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBusca1.Text = dgvVeiculo.CurrentRow.Cells[0].Value.ToString();
            txtFabricante.Text = dgvVeiculo.CurrentRow.Cells[1].Value.ToString();
            txtModelo.Text = dgvVeiculo.CurrentRow.Cells[2].Value.ToString();
            txtAno.Text = dgvVeiculo.CurrentRow.Cells[3].Value.ToString();
            mtxtPlaca.Text = dgvVeiculo.CurrentRow.Cells[4].Value.ToString();
        }

        //botão Listar - veículo
        private void btnListar1_Click_1(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();
            List<Veiculo> listaVeiculos = objVeiculo.Listar();
            dgvVeiculo.DataSource = listaVeiculos;
        }//fim botão Listar - veículo

        //botão Salvar - Veiculo
        private void btnSalvar1_Click_1(object sender, EventArgs e)
        {
                 try
                 {
                    //recupera os dados dos campos de texto
                    string fabricante = txtFabricante.Text;
                    string modelo = txtModelo.Text;
                    int ano = int.Parse(txtAno.Text);
                    string placa = mtxtPlaca.Text;


                    //cria objeto produto
                    Veiculo objVeiculo = new Veiculo();
                    objVeiculo.Fabricante = fabricante;
                    objVeiculo.Modelo = modelo;
                    objVeiculo.Ano = ano;
                    objVeiculo.Placa = placa;

                    //executa o método Cadastrar
                    objVeiculo.Cadastrar();

                    MessageBox.Show("Operação realizada com sucesso.");
                 }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar cadastrar." + ex.Message,
                        "Falha na operação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            txtFabricante.Focus();
            btnAtualizar1.Enabled = true;
            btnExcluir1.Enabled = true;
            btnListar1.Enabled = true;
            btnNovo1.Enabled = true;
            btnSalvar1.Enabled = true;
            btnPesquisar1.Enabled = true;
            txtBusca1.Enabled = true;

        }//botão salvar - veículo
        
        //botão Novo - veiculo
        private void btnNovo1_Click_1(object sender, EventArgs e)
        {
            txtFabricante.Focus();
            btnAtualizar1.Enabled = false;
            btnExcluir1.Enabled = false;
            btnListar1.Enabled = true;
            btnNovo1.Enabled = false;
            btnSalvar1.Enabled = true;
            btnPesquisar1.Enabled = false;
            txtBusca1.Enabled = false;
            
            
        }//fim botão novo - veiculo

        //botão Atualizar - veículo
        private void btnAtualizar1_Click_1(object sender, EventArgs e)
        {
            Veiculo veiculo = new Veiculo();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "UPDATE VEICULO SET fabricante=@fabricante, modelo=@modelo, ano=@ano, placa=@placa where id=@id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", dgvVeiculo.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@fabricante", txtFabricante.Text);
                cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
                cmd.Parameters.AddWithValue("@ano",  veiculo.Ano=int.Parse(txtAno.Text));
                cmd.Parameters.AddWithValue("@placa", mtxtPlaca.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }//fim botão Atualizar - veículo

        //botão excluir - veículo
        private void btnExcluir1_Click_1(object sender, EventArgs e)
        {
            Veiculo veiculopesq = new Veiculo();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "DELETE FROM VEICULO WHERE id=@id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                veiculopesq.Pesquisa = int.Parse(dgvVeiculo.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@id", veiculopesq.Pesquisa);
                cmd.ExecuteNonQuery();

                limpaCampos1();
                


                MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
            finally
            {
                conexao.Close();
            }

            txtFabricante.Text = "";
            txtModelo.Text = "";
            txtAno.Text = "";
            mtxtPlaca.Text = "";
            txtBusca1.Text = "";
        }//fim botão excluir - veículo

        //botão Pesquisar - veículo
        private void btnPesquisar1_Click_1(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();

            objVeiculo.Pesquisa = int.Parse(txtBusca1.Text);
            List<Veiculo> listaVeiculos = objVeiculo.Pesquisar();
            dgvVeiculo.DataSource = listaVeiculos;
        }//fim botão pesquisar - veículo

        private void fmdVeiculo_Load(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();
            List<Veiculo> listaVeiculos = objVeiculo.Listar();
            dgvVeiculo.DataSource = listaVeiculos;
        }
    }
}
