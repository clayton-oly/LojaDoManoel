using LojaDoManoel.Models;

namespace LojaDoManoel.Service
{
    public class EmpacotamentoService : IEmpacotamentoService
    {
        private readonly List<Caixa> _caixasDisponiveis;

        public EmpacotamentoService()
        {
            _caixasDisponiveis = new List<Caixa>
        {
            new Caixa("Caixa 1", 30, 40, 80),
            new Caixa("Caixa 2", 80, 50, 40),
            new Caixa("Caixa 3", 50, 80, 60)
        };
        }

        public List<PedidoEmpacotadoDto> EmpacotarPedidos(List<PedidoDto> pedidos)
        {
            var resultado = new List<PedidoEmpacotadoDto>();

            foreach (var pedido in pedidos)
            {
                var caixasUsadas = new List<CaixaEmpacotadaDto>();
                var produtosNaoEmpacotados = new List<ProdutoDto>(pedido.Produtos);

                foreach (var caixa in _caixasDisponiveis.OrderBy(c => c.CaixaId))
                {
                    var produtosNaCaixa = new List<string>();

                    var cabemNaCaixa = produtosNaoEmpacotados
                        .Where(p => ProdutoCabeNaCaixa(p, caixa))
                        .ToList();

                    if (cabemNaCaixa.Any())
                    {
                        produtosNaCaixa.AddRange(cabemNaCaixa.Select(p => p.ProdutoId));
                        caixasUsadas.Add(new CaixaEmpacotadaDto
                        {
                            CaixaId = caixa.CaixaId,
                            Produtos = produtosNaCaixa
                        });

                        foreach (var p in cabemNaCaixa)
                            produtosNaoEmpacotados.Remove(p);
                    }
                }

                foreach (var produto in produtosNaoEmpacotados)
                {
                    caixasUsadas.Add(new CaixaEmpacotadaDto
                    {
                        CaixaId = null,
                        Produtos = new List<string> { produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }

                resultado.Add(new PedidoEmpacotadoDto
                {
                    PedidoId = pedido.PedidoId,
                    Caixas = caixasUsadas
                });
            }

            return resultado;
        }

        private bool ProdutoCabeNaCaixa(ProdutoDto produto, Caixa caixa)
        {
            return produto.Dimensoes.Altura <= caixa.Altura &&
                   produto.Dimensoes.Largura <= caixa.Largura &&
                   produto.Dimensoes.Comprimento <= caixa.Comprimento;

        }
    }
}