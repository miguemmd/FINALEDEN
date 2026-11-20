using System;
using System.Windows.Forms;

namespace EdenDelivery
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Form1 telaProdutos = new Form1();
            telaProdutos.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos telaPedidos = new FrmPedidos();
            telaPedidos.ShowDialog();
        }

        // como o login só foi escondido (Hide), fechar a principal encerra o programa
        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
