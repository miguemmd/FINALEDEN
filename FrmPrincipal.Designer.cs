using System;
using System.Drawing;
using System.Windows.Forms;

namespace EdenDelivery
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnProdutos = new Button();
            this.btnPedidos = new Button();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Location = new Point(30, 20);
            this.lblTitulo.Text = "Painel do Gerente - EDEN";

            this.btnProdutos.Location = new Point(30, 70);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new Size(290, 45);
            this.btnProdutos.Text = "Gerenciar Cardápio (CRUD)";
            this.btnProdutos.Click += new EventHandler(this.btnProdutos_Click);

            this.btnPedidos.Location = new Point(30, 125);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new Size(290, 45);
            this.btnPedidos.Text = "Pedidos (importar JSON)";
            this.btnPedidos.Click += new EventHandler(this.btnPedidos_Click);

            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(350, 200);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnPedidos);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EDEN - Painel Principal";
            this.FormClosed += new FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitulo;
        private Button btnProdutos;
        private Button btnPedidos;
    }
}
