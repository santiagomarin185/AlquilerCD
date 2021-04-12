using Luisde_Prestamos_Cd.models;
using Luisde_Prestamos_Cd.Response;
using Luisde_Prestamos_Cd.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        //Se declara una variable _miBd de tipo Context privada  
        private readonly Context _miBd;

        //Se crea un constructor de la clase AlquilesController con un parametro de la clase Context
        public AlquileresController(Context miBd)
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
                var lista = _miBd.Alquileres.Include("Cliente").ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = lista;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(AlquileresViewModels oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                Alquileres alquileres = new Alquileres();
                alquileres.noAlquiler = oAlquiler.noAlquiler;
                alquileres.fechaAlquiler = oAlquiler.fechaAlquiler;
                alquileres.valorAlquiler = oAlquiler.valorAlquiler;
                alquileres.ClienteId = oAlquiler.ClienteId;
                _miBd.Alquileres.Add(alquileres);
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
        public IActionResult Update(AlquileresViewModels oAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var alquileres = _miBd.Alquileres.Find(oAlquiler.Id);
                alquileres.noAlquiler = oAlquiler.noAlquiler;
                alquileres.fechaAlquiler = oAlquiler.fechaAlquiler;
                alquileres.valorAlquiler = oAlquiler.valorAlquiler;
                alquileres.ClienteId = oAlquiler.ClienteId;
                _miBd.Alquileres.Update(alquileres);
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
                var alquiler = _miBd.Alquileres.Find(Id);
                _miBd.Alquileres.Remove(alquiler);
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
