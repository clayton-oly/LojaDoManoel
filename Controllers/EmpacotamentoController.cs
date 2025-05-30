using LojaDoManoel.Models;
using LojaDoManoel.Service;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoManoel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpacotamentoController : ControllerBase
    {
        private readonly IEmpacotamentoService _service;

        public EmpacotamentoController(IEmpacotamentoService service)
        {
            _service = service;
        }

        [HttpPost("empacotar")]
        public ActionResult<List<PedidoEmpacotadoDto>> Empacotar([FromBody] PedidoRequest request)
        {
            var resultado = _service.EmpacotarPedidos(request.Pedidos);
            return Ok(resultado);
        }

    }
}
