using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class PedidoRequest
    {
        [JsonPropertyName("pedidos")]
        public List<PedidoDto> Pedidos { get; set; }
    }
}
