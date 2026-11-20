using System;
using System.Drawing;
using System.Windows.Forms;

namespace EdenDelivery
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblSenha = new Label();
            this.txtSenha = new TextBox();
            this.btnEntrar = new Button();
            this.SuspendLayout();

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 25);
            this.lblEmail.Text = "E-mail";

            this.txtEmail.Location = new Point(30, 45);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(280, 23);

            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new Point(30, 85);
            this.lblSenha.Text = "Senha";

            this.txtSenha.Location = new Point(30, 105);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new Size(280, 23);

            this.btnEntrar.Location = new Point(30, 150);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new Size(280, 35);
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Click += new EventHandler(this.btnEntrar_Click);

            this.AcceptButton = this.btnEntrar;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(340, 215);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnEntrar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "EDEN - Login do Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSenha;
        private TextBox txtSenha;
        private Button btnEntrar;
    }
}
