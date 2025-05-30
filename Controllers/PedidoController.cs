using LojaDoManoel.Models;
using LojaDoManoel.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoSaveService;

    public PedidoController(IPedidoService pedidoSaveService)
    {
        _pedidoSaveService = pedidoSaveService;
    }


    [HttpPost("salvar")]
    public async Task<IActionResult> Salvar([FromBody] PedidoEmpacotadoRequestDto request)
    {
        var pedidos = request.PedidosEmpacotados;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _pedidoSaveService.SalvarPedidosAsync(pedidos);

        return Ok(new { mensagem = "Pedidos salvos com sucesso!" });
    }
}
