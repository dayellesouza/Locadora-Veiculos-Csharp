using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmdLocadora objlocadora = new fmdLocadora();
            objlocadora.Show();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmdVeiculo objveiculo = new fmdVeiculo();
            objveiculo.Show();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmdFuncionario objfuncionario = new fmdFuncionario();
            objfuncionario.Show();
        }
    }
}
