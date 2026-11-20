using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EdenDelivery
{
    public partial class FrmPedidos : Form
    {
        // pasta onde o navegador salva o .json do pedido (Downloads).
        // Se o professor pedir outra pasta, troque só esta linha.
        private readonly string pastaJson = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }

        // lista as vendas já salvas no MySQL
        private void ListarPedidos()
        {
            try
            {
                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM pedidos ORDER BY id DESC", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPedidos.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar pedidos: " + ex.Message);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo pasta = new DirectoryInfo(pastaJson);
                FileInfo[] arquivos = pasta.GetFiles("pedido_*.json");

                if (arquivos.Length == 0)
                {
                    MessageBox.Show("Nenhum arquivo pedido_*.json encontrado em: " + pastaJson);
                    return;
                }

                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                int importados = 0;

                // do mais antigo para o mais novo
                foreach (FileInfo arquivo in arquivos.OrderBy(f => f.LastWriteTime))
                {
                    string textoJson = File.ReadAllText(arquivo.FullName);

                    // converte o texto nas classes C# (desserialização)
                    PedidoJson pedidoDoSite = JsonSerializer.Deserialize<PedidoJson>(textoJson);

                    // evita importar o mesmo pedido duas vezes
                    MySqlCommand verifica = new MySqlCommand(
                        "SELECT COUNT(*) FROM pedidos WHERE codigo_pedido = @codigo", conn);
                    verifica.Parameters.AddWithValue("@codigo", pedidoDoSite.PedidoId);

                    if (Convert.ToInt32(verifica.ExecuteScalar()) > 0)
                    {
                        continue;
                    }

                    string sql = "INSERT INTO pedidos (codigo_pedido, nome_cliente, total, status) " +
                                 "VALUES (@codigo, @cliente, @total, 'Pendente')";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@codigo", pedidoDoSite.PedidoId);
                    cmd.Parameters.AddWithValue("@cliente", pedidoDoSite.Cliente.Nome);
                    cmd.Parameters.AddWithValue("@total", pedidoDoSite.Total);

                    cmd.ExecuteNonQuery();
                    importados++;
                }

                conn.Close();

                MessageBox.Show(importados + " pedido(s) importado(s) com sucesso!");
                ListarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar: " + ex.Message);
            }
        }
    }
}
