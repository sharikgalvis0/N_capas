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
    public class PersonaService : IPersonaService
    {
        private readonly PazSalvoContext _context;
        public PersonaService(PazSalvoContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Persona model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            int personaId = model.Id;

            if (personaId == 0 || personaId == null) return result;

            try
            {
                Persona persona = await Leer(personaId);

 
                persona.Nombres = model.Nombres;
                persona.Telefono = model.Telefono;
                persona.CorreoElectronico = model.CorreoElectronico;
                persona.DocumentoIdentificacion = model.DocumentoIdentificacion;

               
                _context.Personas.Update(persona); // Actualización de la factura en el contexto
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

        public async Task<bool> Insertar(Persona model)
        {
            bool result = default(bool); // Inicialización de una variable booleana llamada result

            try
            {
                _context.Personas.Add(model); // Agregar la factura al contexto
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

                return !result; // Devolver el valor inverso de result (true si se insertó correctamente, false si no)
            }
            catch (Exception ex) // Captura de excepciones
            {
                return result; // Devolver el valor por defecto de result (false)
            }
        }

        public async Task<Persona> Leer(int id)
        {
            if (id == default(int)) return null; // Verificar si el ID es cero, si es así, devolver null

            Persona persona = await _context.Personas.FirstOrDefaultAsync(f => f.Id == id);  // Buscar la factura por su ID

            if (persona == null) return null; // Si la factura no se encontró, devolver null

            return persona; // Devolver la factura encontrada
        }

        public async Task<IQueryable<Persona>> LeerTodos()
        {
            IQueryable<Persona> listaDePersonas = _context.Personas; // Obtener todas las facturas del contexto

            return listaDePersonas; // Devolver la lista de facturas
        }
    }
}
