using LojaDoManoel.Models;

namespace LojaDoManoel.Service
{
    public interface IEmpacotamentoService
    {
        List<PedidoEmpacotadoDto> EmpacotarPedidos(List<PedidoDto> pedidos);
    }
}
