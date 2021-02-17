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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                //recupera os dados dos campos de texto
                string Usuario = txtUsuario.Text;
                string Senha = txtSenha.Text;

                //cria objeto produto
                usuario objUsuario = new usuario();
                objUsuario.Usuario = Usuario;
                objUsuario.Senha = Senha;

                //executa o método Cadastrar
                objUsuario.Cadastrar();

                MessageBox.Show("Operação realizada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar." + ex.Message,
                    "Falha na operação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            usuario objUsuario = new usuario();

            objUsuario.Usuario = txtUsuario.Text;
            objUsuario.Senha = txtSenha.Text;

            usuario objusuarioaux = new usuario();
            objusuarioaux = objUsuario.Login();

            if ((objUsuario.Usuario == objusuarioaux.Usuario) && (objUsuario.Senha == objusuarioaux.Senha))
            {
                Principal objprincipal = new Principal();
                objprincipal.Show();
            }
            else
            {

                MessageBox.Show("Usuário e Senha Inválidos");

            }
        }
    }
}
