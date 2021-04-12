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
    public class DetalleAlquileresController : ControllerBase
    {
        private readonly Context _miBd;

        public DetalleAlquileresController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var lista = _miBd.DetalleAlquileres.Include("Alquiler").Include("Cd").ToList();
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
        public IActionResult Add(DetalleAlquileres oDetalle)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                DetalleAlquileres detalle = new DetalleAlquileres();
                detalle.Item = oDetalle.Item;
                detalle.CodigoTitulo = oDetalle.CodigoTitulo;
                detalle.DiasPrestamo = oDetalle.DiasPrestamo;
                detalle.FechaDevolucion = oDetalle.FechaDevolucion;
                detalle.AlquilerId = oDetalle.AlquilerId;
                detalle.CdId = oDetalle.CdId;
                _miBd.DetalleAlquileres.Add(detalle);
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
        public IActionResult Update(DetalleAlquileres oDetalle)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var detalle = _miBd.DetalleAlquileres.Find(oDetalle.Id);
                detalle.Item = oDetalle.Item;
                detalle.CodigoTitulo = oDetalle.CodigoTitulo;
                detalle.DiasPrestamo = oDetalle.DiasPrestamo;
                detalle.FechaDevolucion = oDetalle.FechaDevolucion;
                detalle.AlquilerId = oDetalle.AlquilerId;
                detalle.CdId = oDetalle.CdId;
                _miBd.DetalleAlquileres.Update(detalle);
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
                var detalle = _miBd.DetalleAlquileres.Find(Id);
                _miBd.DetalleAlquileres.Remove(detalle);
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
