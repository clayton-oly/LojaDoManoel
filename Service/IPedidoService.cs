using LojaDoManoel.Models;

namespace LojaDoManoel.Service
{
    public interface IPedidoService
    {
        Task SalvarPedidosAsync(List<PedidoEmpacotadoDto> pedidosEmpacotados);
    }
}
