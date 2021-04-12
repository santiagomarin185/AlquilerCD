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
    public class CdsController : ControllerBase
    {
        //Se declara una variable _miBd de tipo Context privada  
        private readonly Context _miBd;

        //Se crea un constructor de la clase ClienteController con un parametro de la clase Context
        public CdsController(Context miBd)
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
                var lista = _miBd.Cds.ToList();
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
        public IActionResult Add(CdViewModels oCd)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                Cds cds = new Cds();
                cds.CodigoTitulo = oCd.CodigoTitulo;
                cds.NoCd = oCd.NoCd;
                cds.Condicion = oCd.Condicion;
                cds.Ubicacion = oCd.Ubicacion;
                cds.Estado = oCd.Estado;
                _miBd.Cds.Add(cds);
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
        public IActionResult Update(CdViewModels oCd)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var cds = _miBd.Cds.Find(oCd.Id);
                cds.CodigoTitulo = oCd.CodigoTitulo;
                cds.NoCd = oCd.NoCd;
                cds.Condicion = oCd.Condicion;
                cds.Ubicacion = oCd.Ubicacion;
                cds.Estado = oCd.Estado;
                _miBd.Cds.Update(cds);
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
                var cds = _miBd.Cds.Find(Id);
                _miBd.Cds.Remove(cds);
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
