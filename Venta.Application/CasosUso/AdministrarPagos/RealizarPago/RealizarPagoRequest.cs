using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pago.Application.Common;

namespace Pago.Application.CasosUso.AdministrarPagos.RealizarPago
{
    public class RealizarPagoRequest : IRequest<IResult>
    {
        public int IdVenta { get; set; }
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string? NumeroTarjeta { get; set; }
        public string? CVV { get; set; }
        public string? NombreTitular { get; set; }
        public int NumeroCuotas { get; set; }
    }
}