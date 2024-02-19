using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pago.Application.CasosUso.AdministrarPagos.RealizarPago;

namespace Venta.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]//autorizaci´+on
    public class PagosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configInfo;

        public PagosController(IMediator mediator, IConfiguration configInfo)
        {
            _mediator = mediator;
            _configInfo = configInfo;
        }

        [HttpPost("pagar")]
        public async Task<IActionResult> pagar([FromBody] RealizarPagoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
