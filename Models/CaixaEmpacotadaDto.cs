using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{

    public class CaixaEmpacotadaDto
    {
        [JsonPropertyName("caixa_id")]
        public string CaixaId { get; set; }

        [JsonPropertyName("produtos")]
        public List<string> Produtos { get; set; }

        [JsonPropertyName("observacao")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observacao { get; set; }

    }
}
