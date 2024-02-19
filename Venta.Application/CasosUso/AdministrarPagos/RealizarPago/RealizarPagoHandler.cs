using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pago.Application.Common;
using Pago.Domain.Models;
using Pago.Domain.Repositories;

namespace Pago.Application.CasosUso.AdministrarPagos.RealizarPago
{
          
    public class RealizarPagoHandler :
       IRequestHandler<RealizarPagoRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public RealizarPagoHandler(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }


        public async Task<IResult> Handle(RealizarPagoRequest request, CancellationToken cancellationToken)
        {
            //return new SuccessResult();

            IResult response = null;
            bool result = false;

            try
            {
                var pago = _mapper.Map<Pago.Domain.Models.Pago>(request);
                
                result = await _pagoRepository.Pagar(pago);

                if (result)
                {
                    return new SuccessResult();
                }
                else
                    return new FailureResult();

            }
            catch (Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
