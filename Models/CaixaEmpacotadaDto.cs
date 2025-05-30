namespace LojaDoManoel.Models
{
    public class CaixaEmpacotadaDto
    {
        public string CaixaId { get; set; }
        public List<string> Produtos { get; set; }
        public string? Observacao { get; set; }
    }
}