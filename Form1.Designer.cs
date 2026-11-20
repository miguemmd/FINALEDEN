using System;
using System.Drawing;
using System.Windows.Forms;

namespace EdenDelivery
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new Label();
            this.txtId = new TextBox();
            this.lblNome = new Label();
            this.txtNomeProduto = new TextBox();
            this.lblPreco = new Label();
            this.txtPreco = new TextBox();
            this.lblCategoria = new Label();
            this.cmbCategoria = new ComboBox();
            this.btnCadastrar = new Button();
            this.btnAtualizar = new Button();
            this.btnExcluir = new Button();
            this.btnLimpar = new Button();
            this.dgvProdutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();

            this.lblId.AutoSize = true;
            this.lblId.Location = new Point(20, 20);
            this.lblId.Text = "ID";

            this.txtId.Location = new Point(20, 40);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new Size(80, 23);

            this.lblNome.AutoSize = true;
            this.lblNome.Location = new Point(120, 20);
            this.lblNome.Text = "Nome do produto";

            this.txtNomeProduto.Location = new Point(120, 40);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new Size(250, 23);

            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new Point(390, 20);
            this.lblPreco.Text = "Preço";

            this.txtPreco.Location = new Point(390, 40);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new Size(100, 23);

            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new Point(510, 20);
            this.lblCategoria.Text = "Categoria";

            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.Items.AddRange(new object[] { "Poke", "Combo", "Bebida", "Sobremesa" });
            this.cmbCategoria.Location = new Point(510, 40);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(160, 23);

            this.btnCadastrar.Location = new Point(20, 85);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new Size(110, 32);
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.Click += new EventHandler(this.btnCadastrar_Click);

            this.btnAtualizar.Location = new Point(140, 85);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new Size(110, 32);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);

            this.btnExcluir.Location = new Point(260, 85);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new Size(110, 32);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);

            this.btnLimpar.Location = new Point(380, 85);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new Size(110, 32);
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new EventHandler(this.btnLimpar_Click);

            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.Location = new Point(20, 135);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new Size(650, 280);
            this.dgvProdutos.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);

            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(690, 435);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.dgvProdutos);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EDEN - Cardápio (CRUD)";
            this.Load += new EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblId;
        private TextBox txtId;
        private Label lblNome;
        private TextBox txtNomeProduto;
        private Label lblPreco;
        private TextBox txtPreco;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Button btnCadastrar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Button btnLimpar;
        private DataGridView dgvProdutos;
    }
}
