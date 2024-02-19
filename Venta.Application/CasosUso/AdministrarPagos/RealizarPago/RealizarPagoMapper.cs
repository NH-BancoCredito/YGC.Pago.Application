using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pago.Domain.Models;

namespace Pago.Application.CasosUso.AdministrarPagos.RealizarPago
{
    public class RealizarPagoMapper : Profile
    {
        public RealizarPagoMapper()
        {
            CreateMap<RealizarPagoRequest, Pago.Domain.Models.Pago>();
            //    .ForMember();

            //CreateMap<RegistrarVentaRequest, Models.Venta>()
            //    .ForMember(dest => dest.Detalle, map => map.MapFrom(src => src.Productos));
        }
    }
}
