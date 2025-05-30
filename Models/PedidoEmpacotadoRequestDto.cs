using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class PedidoEmpacotadoRequestDto
    {
        [JsonPropertyName("pedidos")] 
        public List<PedidoEmpacotadoDto> PedidosEmpacotados { get; set; }
    }
}
