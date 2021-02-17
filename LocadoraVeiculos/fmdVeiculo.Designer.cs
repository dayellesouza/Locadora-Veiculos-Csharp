namespace LocadoraVeiculos
{
    partial class fmdVeiculo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPesquisar1 = new System.Windows.Forms.Button();
            this.txtBusca1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExcluir1 = new System.Windows.Forms.Button();
            this.btnListar1 = new System.Windows.Forms.Button();
            this.btnAtualizar1 = new System.Windows.Forms.Button();
            this.btnNovo1 = new System.Windows.Forms.Button();
            this.btnSalvar1 = new System.Windows.Forms.Button();
            this.dgvVeiculo = new System.Windows.Forms.DataGridView();
            this.mtxtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar1
            // 
            this.btnPesquisar1.Location = new System.Drawing.Point(476, 48);
            this.btnPesquisar1.Name = "btnPesquisar1";
            this.btnPesquisar1.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar1.TabIndex = 33;
            this.btnPesquisar1.Text = "Pesquisar";
            this.btnPesquisar1.UseVisualStyleBackColor = true;
            this.btnPesquisar1.Click += new System.EventHandler(this.btnPesquisar1_Click_1);
            // 
            // txtBusca1
            // 
            this.txtBusca1.Location = new System.Drawing.Point(447, 22);
            this.txtBusca1.Name = "txtBusca1";
            this.txtBusca1.Size = new System.Drawing.Size(128, 20);
            this.txtBusca1.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Busca por código:";
            // 
            // btnExcluir1
            // 
            this.btnExcluir1.Location = new System.Drawing.Point(500, 185);
            this.btnExcluir1.Name = "btnExcluir1";
            this.btnExcluir1.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir1.TabIndex = 30;
            this.btnExcluir1.Text = "Excluir";
            this.btnExcluir1.UseVisualStyleBackColor = true;
            this.btnExcluir1.Click += new System.EventHandler(this.btnExcluir1_Click_1);
            // 
            // btnListar1
            // 
            this.btnListar1.Location = new System.Drawing.Point(407, 185);
            this.btnListar1.Name = "btnListar1";
            this.btnListar1.Size = new System.Drawing.Size(75, 23);
            this.btnListar1.TabIndex = 29;
            this.btnListar1.Text = "Listar";
            this.btnListar1.UseVisualStyleBackColor = true;
            this.btnListar1.Click += new System.EventHandler(this.btnListar1_Click_1);
            // 
            // btnAtualizar1
            // 
            this.btnAtualizar1.Location = new System.Drawing.Point(253, 185);
            this.btnAtualizar1.Name = "btnAtualizar1";
            this.btnAtualizar1.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar1.TabIndex = 28;
            this.btnAtualizar1.Text = "Atualizar";
            this.btnAtualizar1.UseVisualStyleBackColor = true;
            this.btnAtualizar1.Click += new System.EventHandler(this.btnAtualizar1_Click_1);
            // 
            // btnNovo1
            // 
            this.btnNovo1.Location = new System.Drawing.Point(161, 185);
            this.btnNovo1.Name = "btnNovo1";
            this.btnNovo1.Size = new System.Drawing.Size(75, 23);
            this.btnNovo1.TabIndex = 27;
            this.btnNovo1.Text = "Novo";
            this.btnNovo1.UseVisualStyleBackColor = true;
            this.btnNovo1.Click += new System.EventHandler(this.btnNovo1_Click_1);
            // 
            // btnSalvar1
            // 
            this.btnSalvar1.Location = new System.Drawing.Point(70, 185);
            this.btnSalvar1.Name = "btnSalvar1";
            this.btnSalvar1.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar1.TabIndex = 26;
            this.btnSalvar1.Text = "Salvar";
            this.btnSalvar1.UseVisualStyleBackColor = true;
            this.btnSalvar1.Click += new System.EventHandler(this.btnSalvar1_Click_1);
            // 
            // dgvVeiculo
            // 
            this.dgvVeiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeiculo.Location = new System.Drawing.Point(70, 235);
            this.dgvVeiculo.Name = "dgvVeiculo";
            this.dgvVeiculo.Size = new System.Drawing.Size(505, 150);
            this.dgvVeiculo.TabIndex = 25;
            // 
            // mtxtPlaca
            // 
            this.mtxtPlaca.Location = new System.Drawing.Point(118, 117);
            this.mtxtPlaca.Mask = "AAA-9999";
            this.mtxtPlaca.Name = "mtxtPlaca";
            this.mtxtPlaca.Size = new System.Drawing.Size(100, 20);
            this.mtxtPlaca.TabIndex = 24;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(118, 79);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 23;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(118, 44);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(150, 20);
            this.txtModelo.TabIndex = 22;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(118, 12);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(150, 20);
            this.txtFabricante.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(75, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Placa:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ano:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Modelo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fabricante:";
            // 
            // fmdVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 397);
            this.Controls.Add(this.btnPesquisar1);
            this.Controls.Add(this.txtBusca1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnExcluir1);
            this.Controls.Add(this.btnListar1);
            this.Controls.Add(this.btnAtualizar1);
            this.Controls.Add(this.btnNovo1);
            this.Controls.Add(this.btnSalvar1);
            this.Controls.Add(this.dgvVeiculo);
            this.Controls.Add(this.mtxtPlaca);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "fmdVeiculo";
            this.Text = "fmdVeiculo";
            this.Load += new System.EventHandler(this.fmdVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar1;
        private System.Windows.Forms.TextBox txtBusca1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExcluir1;
        private System.Windows.Forms.Button btnListar1;
        private System.Windows.Forms.Button btnAtualizar1;
        private System.Windows.Forms.Button btnNovo1;
        private System.Windows.Forms.Button btnSalvar1;
        private System.Windows.Forms.DataGridView dgvVeiculo;
        private System.Windows.Forms.MaskedTextBox mtxtPlaca;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}