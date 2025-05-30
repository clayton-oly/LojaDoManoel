using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class PedidoEmpacotadoDto
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("caixas")]
        public List<CaixaEmpacotadaDto> Caixas { get; set; }
    }

}
