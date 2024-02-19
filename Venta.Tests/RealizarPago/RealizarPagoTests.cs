using AutoMapper;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Pago.Application.CasosUso.AdministrarPagos.RealizarPago;
using Pago.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Venta.Application.CasosUso.AdministrarPagos.RealizarPago;

namespace Pago.Tests.RealizarPago
{
    public class RealizarPagoTests
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;
        private readonly RealizarPagoHandler _realizarPagoHandler;
        public RealizarPagoTests()
        {
            _mapper = new MapperConfiguration(c => c.AddProfile<RealizarPagoMapper>()).CreateMapper();
            _pagoRepository = Substitute.For<IPagoRepository>();
            _realizarPagoHandler = Substitute.For<RealizarPagoHandler>(_pagoRepository, _mapper);
        }
        [Fact]
        public async Task RegistrarPagosError()
        {
            var request = new RealizarPagoRequest() { IdVenta = 1 };
            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;
            Random gen = new Random();
            int prob = gen.Next(100);
            bool resultado = prob < 51;
            _pagoRepository.Adicionar(default).ReturnsForAnyArgs(resultado);

            cts.Cancel();
            var retorno = await _realizarPagoHandler.Handle(request, cancellationToken);

            /// Assert.True(lista.count>0);
            Assert.False(retorno.HasSucceeded);

        }

        [Fact]
        public async Task RegistrarPagosException()
        {

            var request = new RealizarPagoRequest() { IdVenta = 1 };
            CancellationTokenSource cts = new();
            CancellationToken cancellationToken = cts.Token;

            //Escenarios
            _pagoRepository.Adicionar(default).ThrowsForAnyArgs<Exception>();

            cts.Cancel();
            Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _realizarPagoHandler.Handle(request, cancellationToken);
            });


        }

    }
}
