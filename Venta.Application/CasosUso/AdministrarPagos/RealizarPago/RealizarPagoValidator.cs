using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.Application.CasosUso.AdministrarPagos.RealizarPago
{
    public class RealizarPagoValidator : AbstractValidator<RealizarPagoRequest>
    {
        public RealizarPagoValidator()
        {
            RuleFor(item => item.IdVenta).NotEmpty().WithMessage("Error al enviar el IdVenta");
            RuleFor(item => item.Monto).NotEmpty().WithMessage("Debe especificar un Monto");
            RuleFor(item => item.FormaPago).LessThan(2).WithMessage("Debe de tener los valores 1: Tarjeta Crédito, 2: Tarjeta Débito, 3: Yape (todavía no está implementado");
            RuleFor(item => item.CVV).Length(3,3).WithMessage("Debe tener código CVV");
            RuleFor(item => new { item.NumeroTarjeta, item.FormaPago }).Must(x => ValidacionNroTarjeta(x.NumeroTarjeta, x.FormaPago))
                                      .WithMessage("Número de Tarjeta obligatorio");
            RuleFor(item => new { item.NumeroCuotas, item.FormaPago }).Must(x => ValidacionNroCuotas(x.NumeroCuotas, x.FormaPago))
                                      .WithMessage("Número de cuotas obligatorio");
            RuleFor(item => new { item.NombreTitular, item.FormaPago }).Must(x => ValidacionTitular(x.NombreTitular, x.FormaPago))
                                      .WithMessage("Titular obligatorio de cuotas obligatorio");
            RuleFor(item => new { item.CVV, item.FormaPago }).Must(x => ValidacionCVV(x.CVV, x.FormaPago))
                                      .WithMessage("Debe tener código CVV");
        }

        private bool ValidacionNroTarjeta(string NumeroTarjeta, int FormaPago)
        {
            if ((FormaPago == 1 || FormaPago == 2) && NumeroTarjeta.Trim() == String.Empty)
                return false;
            return true;

        }
        private bool ValidacionNroCuotas(int NumeroCuotas, int FormaPago)
        {
            if ((FormaPago == 1 || FormaPago == 2) && NumeroCuotas == 0)
                return false;
            return true;

        }
        private bool ValidacionTitular(string NombreTitular, int FormaPago)
        {
            if ((FormaPago == 1 || FormaPago == 2) && NombreTitular.Trim() == String.Empty)
                return false;
            return true;

        }
        private bool ValidacionCVV(string CVV, int FormaPago)
        {
            if ((FormaPago == 1 || FormaPago == 2) && CVV.Trim().Length != 3)
                return false;
            return true;

        }
    }
    
}
