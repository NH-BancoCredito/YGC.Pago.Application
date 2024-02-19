using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pago.Domain.Repositories;
using Pago.Domain.Models;
using Pago.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;



namespace Venta.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly VentaDbContext _context;
        public PagoRepository(VentaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Pagar(Pago.Domain.Models.Pago entity)
        {
            try
            {
                Random gen = new Random();
                int prob = gen.Next(100);
                bool resultado = prob < 51;// respuesta aleatoria

                //return resultado;
                if (resultado)
                {

                    entity.Monto = Convert.ToDecimal(entity.Monto);
                    _context.Pagos.Add(entity);
                    await _context.SaveChangesAsync();
                }
                return resultado;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();

            }
        }
        public  async Task<bool> Adicionar(Pago.Domain.Models.Pago entity)
        {
            //try
            //{
            //    entity.PrecioUnitario = Convert.ToDecimal(entity.PrecioUnitario);
            //  _context.Productos.Add(entity);
            //    await _context.SaveChangesAsync();
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    throw new NotImplementedException();

            //}
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pago.Domain.Models.Pago>> Consultar(string nombre)
        {
            //try {
            //    return await _context.Productos.Include(p => p.Categoria).ToListAsync();
            //}
            //catch (Exception e)
            //{
            //    throw new NotImplementedException();
            //}
            throw new NotImplementedException();
            //return await _context.Productos.ToListAsync();

        }

        public async Task<Pago.Domain.Models.Pago> ConsultarById(int id)
        {
            
            try
            {
                //return await _context.Productos.FindAsync(id);
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public Task<bool> Eliminar(Pago.Domain.Models.Pago entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Modificar(Pago.Domain.Models.Pago entity)
        {
            throw new NotImplementedException();
            ////try
            ////{
            ////    var productoencontrado = await _context.Productos.FindAsync(entity.IdProducto);
            ////    productoencontrado.Stock = entity.Stock;
            ////    await _context.SaveChangesAsync();
            ////    return true;
            ////    //_context.Entry..Attach(entity);
            ////    //await _context.Attach(entity);


            ////    //context.Entry.Attach(entidad);
            ////    //context.Entry(entidad).Property(x => x.campo1).IsModified = true;
            ////    //db.SaveChanges();
            ////    //db.Entry(user).Property(x => x.Password).IsModified = true;
            ////    //context.Entry.Attach(entidad);
            ////    //context.Entry(entidad).Property(x => x.campo1).IsModified = true;
            ////    //db.SaveChanges();

            ////    //db.Entry(user).Property(x => x.Password).IsModified = true;
            ////    return true;

            ////    //context.Entry.Attach(entidad);
            ////    //context.Entry(entidad).Property(x => x.campo1).IsModified = true;
            ////    //db.SaveChanges();
            ////}
            ////catch (Exception e)
            ////{
            ////    throw new NotImplementedException();

            ////}

        }
    }
}

