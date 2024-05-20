using Microsoft.EntityFrameworkCore;
using PazYSalvoAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazYSalvoAPP.Business.Services
{
    public class PagoService : IPagoService
    {
        private readonly PazSalvoContext _context;
        public PagoService(PazSalvoContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Pago model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            int pagoId = model.Id;

            if (pagoId == 0 || pagoId == null) return result;

            try
            {
                Pago pago = await Leer(pagoId);


                pago.MontoDePago = model.MontoDePago;
                pago.FacturaId = model.FacturaId;
                pago.Activo = model.Activo;
               


                _context.Pagos.Update(pago); // Actualización de la factura en el contexto
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

                return !result; // Devolver el valor inverso de result (true si se actualizó correctamente, false si no)
            }
            catch (Exception ex) // Captura de excepciones
            {
                return result; // Devolver el valor por defecto de result (false)
            }
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Pago model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            try
            {
                _context.Pagos.Add(model); // Agregar la factura al contexto
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

                return !result; // Devolver el valor inverso de result (true si se insertó correctamente, false si no)
            }
            catch (Exception ex) // Captura de excepciones
            {
                return result; // Devolver el valor por defecto de result (false)
            }
        }

        public async Task<Pago> Leer(int id)
        {
            if (id == default(int)) return null; // Verificar si el ID es cero, si es así, devolver null

            Pago pago = await _context.Pagos.FirstOrDefaultAsync(f => f.Id == id);  // Buscar la factura por su ID

            if (pago == null) return null; // Si la factura no se encontró, devolver null

            return pago; // Devolver la factura encontrada
        }

        public async Task<IQueryable<Pago>> LeerTodos()
        {
            IQueryable<Pago> listaDePagos = _context.Pagos; // Obtener todas las facturas del contexto

            return listaDePagos; // Devolver la lista de facturas
        }
    }
}
