namespace EdenDelivery
{
    public class Produto
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Preco { get; set; }
        public string Categoria { get; set; }
    }
}
