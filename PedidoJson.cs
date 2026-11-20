using System.Text.Json.Serialization;

namespace EdenDelivery
{
    // moldes do arquivo .json gerado pelo site (função exportarPedidoJson do script.js)

    public class ClienteJson
    {
        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("Cep")]
        public string Cep { get; set; }
    }

    public class ItemJson
    {
        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("Quantidade")]
        public int Quantidade { get; set; }
    }

    public class PedidoJson
    {
        [JsonPropertyName("PedidoId")]
        public string PedidoId { get; set; }

        [JsonPropertyName("Cliente")]
        public ClienteJson Cliente { get; set; }

        [JsonPropertyName("Itens")]
        public List<ItemJson> Itens { get; set; }

        [JsonPropertyName("Total")]
        public decimal Total { get; set; }

        [JsonPropertyName("Data")]
        public string Data { get; set; }
    }
}
