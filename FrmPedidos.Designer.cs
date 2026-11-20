using System;
using System.Drawing;
using System.Windows.Forms;

namespace EdenDelivery
{
    partial class FrmPedidos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnImportar = new Button();
            this.dgvPedidos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();

            this.btnImportar.Location = new Point(20, 20);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new Size(200, 35);
            this.btnImportar.Text = "Importar pedidos (JSON)";
            this.btnImportar.Click += new EventHandler(this.btnImportar_Click);

            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.Location = new Point(20, 70);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new Size(650, 300);

            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(690, 390);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.dgvPedidos);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPedidos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EDEN - Pedidos";
            this.Load += new EventHandler(this.FrmPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
        }

        private Button btnImportar;
        private DataGridView dgvPedidos;
    }
}
