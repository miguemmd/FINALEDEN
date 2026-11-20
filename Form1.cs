using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EdenDelivery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ---------- READ (listar) ----------
        private void ListarProdutos()
        {
            try
            {
                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                string sql = "SELECT * FROM produtos";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd); // o "caminhão"
                DataTable dt = new DataTable();                   // a "caixa"
                da.Fill(dt);

                dgvProdutos.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produtos: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarProdutos();
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNomeProduto.Clear();
            txtPreco.Clear();
            cmbCategoria.SelectedIndex = -1;
        }

        // ---------- CREATE (cadastrar) ----------
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto objProduto = new Produto();
                objProduto.Nome = txtNomeProduto.Text;
                objProduto.Preco = double.Parse(txtPreco.Text);
                objProduto.Categoria = cmbCategoria.Text;

                Conexao banco = new Conexao();
                MySqlConnection conexaoAberta = banco.conectarBD();

                string sql = "INSERT INTO produtos (nome, preco, categoria) VALUES (@nome, @preco, @categoria)";

                MySqlCommand comando = new MySqlCommand(sql, conexaoAberta);
                comando.Parameters.AddWithValue("@nome", objProduto.Nome);
                comando.Parameters.AddWithValue("@preco", objProduto.Preco);
                comando.Parameters.AddWithValue("@categoria", objProduto.Categoria);

                comando.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");

                LimparCampos();
                conexaoAberta.Close();
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        // ---------- seleciona a linha com dois cliques ----------
        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvProdutos.Rows[e.RowIndex];

                txtId.Text = linha.Cells["id"].Value.ToString();
                txtNomeProduto.Text = linha.Cells["nome"].Value.ToString();
                txtPreco.Text = linha.Cells["preco"].Value.ToString();
                cmbCategoria.Text = linha.Cells["categoria"].Value.ToString();
            }
        }

        // ---------- UPDATE (atualizar) ----------
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecione um produto na lista primeiro!");
                return;
            }

            try
            {
                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                string sql = "UPDATE produtos SET nome = @nome, preco = @preco, categoria = @categoria WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", txtNomeProduto.Text);
                cmd.Parameters.AddWithValue("@preco", Convert.ToDouble(txtPreco.Text));
                cmd.Parameters.AddWithValue("@categoria", cmbCategoria.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Produto atualizado com sucesso!");
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        // ---------- DELETE (excluir) ----------
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecione um produto na lista primeiro para excluir!");
                return;
            }

            DialogResult resposta = MessageBox.Show("Tem certeza que deseja excluir este produto?",
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resposta == DialogResult.Yes)
            {
                try
                {
                    Conexao banco = new Conexao();
                    MySqlConnection conn = banco.conectarBD();

                    string sql = "DELETE FROM produtos WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Produto excluído!");
                    LimparCampos();
                    ListarProdutos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
