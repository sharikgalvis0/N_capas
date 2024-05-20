using Microsoft.EntityFrameworkCore;
using PazYSalvoAPP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazYSalvoAPP.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly PazSalvoContext _context;
        public ClienteService(PazSalvoContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Cliente model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            int clienteId = model.Id;

            if (clienteId == 0 || clienteId == null) return result;
           

            try
            {
                Cliente cliente = await Leer(clienteId);

                

                cliente.PersonaId = model.PersonaId;
                cliente.RolId = model.RolId;
               
                _context.Clientes.Update(cliente); // Actualización de la factura en el contexto
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

        public async Task<bool> Insertar(Cliente model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            try
            {
                _context.Clientes.Add(model); // Agregar la factura al contexto
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

                return !result; // Devolver el valor inverso de result (true si se insertó correctamente, false si no)
            }
            catch (Exception ex) // Captura de excepciones
            {
                return result; // Devolver el valor por defecto de result (false)
            }
        }

        public async Task<Cliente> Leer(int id)
        {
            if (id == default(int)) return null; // Verificar si el ID es cero, si es así, devolver null

            Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(f => f.Id == id);  // Buscar la factura por su ID

            if (cliente == null) return null; // Si la factura no se encontró, devolver null

            return cliente; // Devolver la factura encontrada
        }

        public async Task<IQueryable<Cliente>> LeerTodos()
        {
            IQueryable<Cliente> listaDeClientes = _context.Clientes; // Obtener todas las facturas del contexto

            return listaDeClientes; // Devolver la lista de facturas
        }
    }
}
