using LojaDoManoel.Models;
using LojaDoManoel.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly LojaDoManoelContext _context;

    public PedidoController(LojaDoManoelContext context)
    {
        _context = context;
    }

    [HttpPost("salvar")]
    public async Task<IActionResult> SalvarPedido([FromBody] PedidoDto pedidoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pedido = new Pedido();

        foreach (var prodDto in pedidoDto.Produtos)
        {
            var produto = new Produto
            {
                ProdutoCodigo = prodDto.ProdutoId,
                Altura = prodDto.Dimensoes.Altura,
                Largura = prodDto.Dimensoes.Largura,
                Comprimento = prodDto.Dimensoes.Comprimento
            };

            pedido.Produtos.Add(produto);
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return Ok(new { pedido_id = pedido.PedidoId });
    }
}
