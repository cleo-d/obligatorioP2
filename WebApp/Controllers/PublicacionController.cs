﻿using Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
            IEnumerable<Publicacion> publicaciones = s.GetPublicaciones();
            
            return View(publicaciones);
        }

        public IActionResult Detalles(int id)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
           
            return View(publicacionEncontrada);
        }

        
        public IActionResult Comprar(int id)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioCierrePublicacion = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));


            publicacionEncontrada.CerrarPublicacion(usuarioCierrePublicacion);

            return RedirectToAction("Index");
        }
        public IActionResult HacerOferta(int id, double monto)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioOferta = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));
            //s.AgregarOfertaAPublicacion(id, usuarioOferta, monto);

            return RedirectToAction("Index");

        }


    }
}