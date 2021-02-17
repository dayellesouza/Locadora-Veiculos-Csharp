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
    public partial class fmdFuncionario : Form
    {
        List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public fmdFuncionario()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------//
        //Fabricante

       

        //prencher dgv
        private void preencherDataGridView2()
        {
            dgvFuncionario.Rows.Clear();

            for (int i = 0; i < listaFuncionarios.Count; i++)
            {
                string[] nova_linha = new string[]
                {
                    listaFuncionarios[i].Nome,
                    listaFuncionarios[i].Cargo,
                    listaFuncionarios[i].Salario.ToString(),
                    listaFuncionarios[i].Endereco,
                    listaFuncionarios[i].Cidade,
                    listaFuncionarios[i].Cep,
                };

                dgvFuncionario.Rows.Add(nova_linha);
            }

        } //fim preencher dgv

      

        private void limpaCampos2()
        {
            txtBusca2.Clear();
            txtNome2.Clear();
            txtCargo.Clear();
            txtSalario.Clear();
            txtEndereco2.Clear();
            txtCidade2.Clear();
            mtxtCEP2.Clear();
        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBusca2.Text = dgvFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome2.Text = dgvFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtCargo.Text = dgvFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtSalario.Text = dgvFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEndereco2.Text = dgvFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtCidade2.Text = dgvFuncionario.CurrentRow.Cells[5].Value.ToString();
            mtxtCEP2.Text = dgvFuncionario.CurrentRow.Cells[6].Value.ToString();
        }


   
        //botão salvar - funcionario
        private void btnSalvar2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //recupera os dados dos campos de texto
                string nome = txtNome2.Text;
                string cargo = txtCargo.Text;
                float salario = float.Parse(txtSalario.Text);
                string endereco = txtEndereco2.Text;
                string cidade = txtCidade2.Text;
                string cep = mtxtCEP2.Text;


                //cria objeto produto
                Funcionario objFuncionario = new Funcionario();
                objFuncionario.Nome = nome;
                objFuncionario.Cargo = cargo; ;
                objFuncionario.Salario = salario;
                objFuncionario.Endereco = endereco;
                objFuncionario.Cidade = cidade;
                objFuncionario.Cep = cep;

                //executa o método Cadastrar
                objFuncionario.Cadastrar();

                MessageBox.Show("Operação realizada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar." + ex.Message,
                    "Falha na operação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            txtNome2.Focus();
            txtBusca2.Enabled = true;
            btnPesquisar2.Enabled = true;
            btnAtualizar2.Enabled = true;
            btnExcluir2.Enabled = true;
            btnNovo2.Enabled = true;
            btnListar2.Enabled = true;
            btnSalvar2.Enabled = true;
        }// fim botão salvar - funcionario

        //botão novo - funcionario
        private void btnNovo2_Click_1(object sender, EventArgs e)
        {
            txtNome2.Focus();
            txtBusca2.Enabled = false;
            btnPesquisar2.Enabled = false;
            btnAtualizar2.Enabled = false;
            btnExcluir2.Enabled = false;
            btnNovo2.Enabled = false;
            btnListar2.Enabled = true;
            btnSalvar2.Enabled = true;
        }//fim botão novo - funcionario

        //botão atualizar - funcionario
        private void btnAtualizar2_Click_1(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "UPDATE FUNCIONARIO SET nome=@nome, cargo=@cargo, salario=@salario, endereco=@endereco, cidade=@cidade, cep=@cep where id=@id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", dgvFuncionario.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@nome", txtNome2.Text);
                cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);
                cmd.Parameters.AddWithValue("@salario", funcionario.Salario=float.Parse(txtSalario.Text));
                cmd.Parameters.AddWithValue("@endereco", txtEndereco2.Text);
                cmd.Parameters.AddWithValue("@cidade", txtCidade2.Text);
                cmd.Parameters.AddWithValue("@cep", mtxtCEP2.Text);
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
        }//fim botão listar - funcionario

        //botão Listar - Funcionario
        private void btnListar2_Click_1(object sender, EventArgs e)
        {
            Funcionario objFuncionario = new Funcionario();
            List<Funcionario> listaFuncionarios = objFuncionario.Listar();
            dgvFuncionario.DataSource = listaFuncionarios;
        }//fim botão listar - funcionario

        //botão excluir - funcionario
        private void btnExcluir2_Click_1(object sender, EventArgs e)
        {
            Funcionario funcionariopesq = new Funcionario();
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "DELETE FROM FUNCIONARIO WHERE id=@id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                funcionariopesq.Pesquisa = int.Parse(dgvFuncionario.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@id", funcionariopesq.Pesquisa);
                cmd.ExecuteNonQuery();

                limpaCampos2();
              

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

            txtNome2.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
            txtEndereco2.Text = "";
            txtCidade2.Text = "";
            mtxtCEP2.Text = "";
            txtBusca2.Text = "";
        }// fim botão excluir - funcionario

        //botão pesquisar - funcionario
        private void btnPesquisar2_Click_1(object sender, EventArgs e)
        {
            Funcionario objFuncionario = new Funcionario();

            objFuncionario.Pesquisa = int.Parse(txtBusca2.Text);
            List<Funcionario> listafuncionarios = objFuncionario.Pesquisar();
            dgvFuncionario.DataSource = listafuncionarios;
        }//fim botão pesquisar - funcionario

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtxtCEP2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtxtSalario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtSalario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void fmdFuncionario_Load(object sender, EventArgs e)
        {
            Funcionario objFuncionario = new Funcionario();
            List<Funcionario> listaFuncionarios = objFuncionario.Listar();
            dgvFuncionario.DataSource = listaFuncionarios;
        }
    }
}
