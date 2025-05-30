namespace LojaDoManoel.Models
{
    public class PedidoEmpacotadoDto
    {
        public int PedidoId { get; set; }
        public List<CaixaEmpacotadaDto> Caixas { get; set; }
    }

}
