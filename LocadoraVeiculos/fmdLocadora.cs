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
    
    public partial class fmdLocadora : Form
    {
        List<Cliente> listaClientes = new List<Cliente>();
       


        public fmdLocadora()
        {

            InitializeComponent();
        }


        //prencher dgv
        private void preencherDataGridView()
        {
            dgvCliente.Rows.Clear();

            for (int i = 0; i < listaClientes.Count; i++)
            {
                string[] nova_linha = new string[]
                {
                    listaClientes[i].Nome,
                    listaClientes[i].Cnh,
                    listaClientes[i].Endereco,
                    listaClientes[i].Cidade,
                    listaClientes[i].Cep,
                };

                dgvCliente.Rows.Add(nova_linha);
            }

        } //fim preencher dgv

        //botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //recupera os dados dos campos de texto
                string nome = txtNome.Text;
                string cnh = mtxtCNH.Text;
                string endereco = txtEndereco.Text;
                string cidade = txtCidade.Text;
                string cep = mtxtCEP.Text; 


                //cria objeto produto
                Cliente objCliente = new Cliente();
                objCliente.Nome = nome;
                objCliente.Cnh = cnh;
                objCliente.Endereco = endereco;
                objCliente.Cidade = cidade;
                objCliente.Cep = cep;

                //executa o método Cadastrar
                objCliente.Cadastrar();

                MessageBox.Show("Operação realizada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar." + ex.Message,
                    "Falha na operação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            txtBusca.Enabled = true;
            txtNome.Enabled = true;
            mtxtCNH.Enabled = true;
            btnAtualizar.Enabled = true;
            btnPesquisar.Enabled = true;

        } //fim botão salvar


        private void limpaCampos()
        {
            txtNome.Clear();
            mtxtCNH.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            mtxtCEP.Clear();
            txtBusca.Clear();
        }


        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBusca.Text = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            mtxtCNH.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
            mtxtCEP.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
            txtEndereco.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
            txtCidade.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();
        }


        //botão Listar
        private void btnListar_Click_1(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();
            List<Cliente> listaClientes = objCliente.Listar();
            dgvCliente.DataSource = listaClientes;
        } //fim botão Listar

        //botão Excluir
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Cliente clientepesq = new Cliente();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "DELETE FROM CLIENTE WHERE id=@id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                clientepesq.Pesquisa = int.Parse(dgvCliente.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@id", clientepesq.Pesquisa);
                cmd.ExecuteNonQuery();

                limpaCampos();
                

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

            txtNome.Text = "";
            mtxtCNH.Text = "";
            mtxtCEP.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
        } //fim botão Excluir


        //botão Pesquisar
        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();

            objCliente.Pesquisa = int.Parse(txtBusca.Text);
            List<Cliente> listaClientes = objCliente.Pesquisar();
            dgvCliente.DataSource = listaClientes;
        }//fim botão Pesquisar

        //botão Novo
        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            txtNome.Focus();
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            txtBusca.Enabled = false;
            txtNome.Enabled = true;
            mtxtCNH.Enabled = true;
            btnAtualizar.Enabled = false;
            btnPesquisar.Enabled = false;
            
        }//fim botão novo

        //botão Atualizar
        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "UPDATE CLIENTE SET nome=@nome, cnh=@cnh,endereco=@endereco, cidade=@cidade, cep=@cep where id=@id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", dgvCliente.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cnh", mtxtCNH.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("@cep", mtxtCEP.Text);
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
        }//fim botão Atualizar

        private void fmdLocadora_Load_1(object sender, EventArgs e)
        { 

            Cliente objCliente = new Cliente();
            List<Cliente> listaClientes = objCliente.Listar();
            dgvCliente.DataSource = listaClientes;
        }
    }
}