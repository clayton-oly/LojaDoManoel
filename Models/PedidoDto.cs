using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class PedidoDto
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("produtos")]
        public List<ProdutoDto> Produtos { get; set; }
    }
}
