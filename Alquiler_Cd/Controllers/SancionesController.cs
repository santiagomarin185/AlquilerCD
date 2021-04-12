using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Luisde_Prestamos_Cd.models;
using Luisde_Prestamos_Cd.Response;
using Luisde_Prestamos_Cd.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Luisde_Prestamos_Cd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionesController : ControllerBase
    {
        //Se declara una variable _miBd de tipo Context privada  
        private readonly Context _miBd;

        //Se crea un constructor de la clase ClienteController con un parametro de la clase Context
        public SancionesController(Context miBd)
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
                var lista = _miBd.Sanciones.Include("Alquiler").ToList();
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
        public IActionResult Add(SancionesViewModels oSanciones)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                Sanciones sanciones = new Sanciones();
                sanciones.NoSancion = oSanciones.NoSancion;
                sanciones.TipoSancion = oSanciones.TipoSancion;
                sanciones.NoDiasSancion = oSanciones.NoDiasSancion;
                sanciones.AlquilerId = oSanciones.AlquilerId;
                _miBd.Sanciones.Add(sanciones);
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
        public IActionResult Update(SancionesViewModels oSanciones)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var sanciones = _miBd.Sanciones.Find(oSanciones.Id);
                sanciones.NoSancion = oSanciones.NoSancion;
                sanciones.TipoSancion = oSanciones.TipoSancion;
                sanciones.NoDiasSancion = oSanciones.NoDiasSancion;
                sanciones.AlquilerId = oSanciones.AlquilerId;
                _miBd.Sanciones.Update(sanciones);
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
                var sanciones = _miBd.Sanciones.Find(Id);
                _miBd.Sanciones.Remove(sanciones);
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
