using LojaDoManoel.Models;

namespace LojaDoManoel.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly LojaDoManoelContext _context;

        public PedidoService(LojaDoManoelContext context)
        {
            _context = context;
        }

        public async Task SalvarPedidosAsync(List<PedidoEmpacotadoDto> pedidosEmpacotados)
        {
            foreach (var pedidoDto in pedidosEmpacotados)
            {
                var pedidoEntity = new Pedido
                {
                    Caixas = pedidoDto.Caixas.Select(c => new CaixaEntity
                    {
                        CaixaId = c.CaixaId,
                        Produtos = string.Join(", ", c.Produtos),
                        Observacao = c.Observacao
                    }).ToList()
                };

                _context.Pedidos.Add(pedidoEntity);
            }

            await _context.SaveChangesAsync();

        }
    }
}
