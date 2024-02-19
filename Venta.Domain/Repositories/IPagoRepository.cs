using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pago.Domain.Models;

namespace Pago.Domain.Repositories
{
    public interface IPagoRepository : IRepository
    {
        Task<bool> Pagar(Pago.Domain.Models.Pago entity);

        Task<bool> Adicionar(Pago.Domain.Models.Pago entity);

        Task<bool> Modificar(Pago.Domain.Models.Pago entity);

        Task<bool> Eliminar(Pago.Domain.Models.Pago entity);

        Task<Pago.Domain.Models.Pago> ConsultarById(int id);

        Task<IEnumerable<Pago.Domain.Models.Pago>> Consultar(string nombre);
        /*bool Adicionar(Producto entity);
        bool Modificar(Producto entity);

        bool Eliminar(Producto entity);

        Producto Consultar(int id);

        IEnumerable<Producto> Consultar(string nombre);*/
        


    }
}
