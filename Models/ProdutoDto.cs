using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class ProdutoDto
    {
        [Required]
        [JsonPropertyName("produto_id")]
        public string ProdutoId { get; set; }

        [JsonPropertyName("dimensoes")]
        public DimensoesDto Dimensoes { get; set; }
    }
}
