using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EdenDelivery
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                string sql = "SELECT * FROM usuarios WHERE email = @email AND senha = @senha";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                MySqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.Read())
                {
                    FrmPrincipal telaPrincipal = new FrmPrincipal();
                    telaPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos!");
                }

                leitor.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message);
            }
        }
    }
}
