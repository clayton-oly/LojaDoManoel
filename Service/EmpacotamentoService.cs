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

                foreach (var produto in pedido.Produtos)
                {
                    var caixa = EncontrarCaixaParaProduto(produto);

                    if (caixa == null)
                    {
                        caixasUsadas.Add(new CaixaEmpacotadaDto
                        {
                            CaixaId = null,
                            Produtos = new List<string> { produto.ProdutoId },
                            Observacao = "Produto não cabe em nenhuma caixa disponível."
                        });
                    }
                    else
                    {
                        var caixaExistente = caixasUsadas
                            .FirstOrDefault(c => c.CaixaId == caixa.CaixaId && c.Observacao == null);

                        if (caixaExistente == null)
                        {
                            caixaExistente = new CaixaEmpacotadaDto
                            {
                                CaixaId = caixa.CaixaId,
                                Produtos = new List<string>()
                            };
                            caixasUsadas.Add(caixaExistente);
                        }

                        caixaExistente.Produtos.Add(produto.ProdutoId);
                    }
                }

                resultado.Add(new PedidoEmpacotadoDto
                {
                    PedidoId = pedido.PedidoId,
                    Caixas = caixasUsadas
                });
            }

            return resultado;
        }

        private Caixa EncontrarCaixaParaProduto(ProdutoDto produto)
        {
            return _caixasDisponiveis
                .FirstOrDefault(c =>
                    produto.Dimensoes.Altura <= c.Altura &&
                    produto.Dimensoes.Largura <= c.Largura &&
                    produto.Dimensoes.Comprimento <= c.Comprimento);
        }

    }
}