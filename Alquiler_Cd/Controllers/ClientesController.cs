using Luisde_Prestamos_Cd.models;
using Luisde_Prestamos_Cd.Response;
using Luisde_Prestamos_Cd.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //Se declara una variable _miBd de tipo Context privada  
        private readonly Context _miBd;

        //Se crea un constructor de la clase ClienteController con un parametro de la clase Context
        public ClientesController(Context miBd)
        {
            _miBd = miBd;
        }
        //Metodo para Listar Resgistros
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var lista = _miBd.Clientes.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = lista;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
        //Metodo para Crear Resgistros
        [HttpPost]
        public IActionResult Add(ClientesViewModels oClientes)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                Clientes clientes = new Clientes();
                clientes.Direccion = oClientes.Direccion;
                clientes.Telefono = oClientes.Telefono;
                clientes.Nombre = oClientes.Nombre;
                clientes.Correo = oClientes.Correo;
                clientes.NroDNI = oClientes.NroDNI;
                clientes.FechaNacimiento = oClientes.FechaNacimiento;
                clientes.FechaInscripcion = oClientes.FechaInscripcion;
                clientes.TemaInteres = oClientes.TemaInteres;
                clientes.Estado = oClientes.Estado;
                _miBd.Clientes.Add(clientes);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
        //Metodo para Actualizar Registros
        [HttpPut]
        public IActionResult Update(ClientesViewModels oClientes)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var clientes = _miBd.Clientes.Find(oClientes.Id);
                clientes.Direccion = oClientes.Direccion;
                clientes.Telefono = oClientes.Telefono;
                clientes.Nombre = oClientes.Nombre;
                clientes.Correo = oClientes.Correo;
                clientes.NroDNI = oClientes.NroDNI;
                clientes.FechaNacimiento = oClientes.FechaNacimiento;
                clientes.FechaInscripcion = oClientes.FechaInscripcion;
                clientes.TemaInteres = oClientes.TemaInteres;
                clientes.Estado = oClientes.Estado;
                _miBd.Clientes.Update(clientes);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }
        //Metodo para Borrar Resgistros
        [HttpDelete("{id}")]
        public IActionResult borrar(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var clientes = _miBd.Clientes.Find(Id);
                _miBd.Clientes.Remove(clientes);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }


    }
}
