﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_PreguntadORT.Models;

namespace TP7_PreguntadORT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
          ViewBag.Puntaje = Juego.ObtenerPuntajesC();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

     public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        
        ViewBag.Categorias = Juego.ObtenerCategorias();
        ViewBag.Dificultades = Juego.ObtenerDificultades();
         

        return View("ConfigurarJuego");
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria){

        Juego.CargarPartida(username,dificultad,categoria);
        
        return RedirectToAction("Jugar" , "Home" );
    }

       public IActionResult Jugar(){  
        Preguntas pregunta = Juego.ObtenerProximaPregunta(); 
        if(pregunta != null){
            List<Respuestas> resp = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
            ViewBag.ContenidoRespuesta = resp;
            ViewBag.ContenidoPregunta = pregunta;
            ViewBag.user = Juego.Username;
            
            return View("Juego");
        }

        DateTime fechaActual = new DateTime();
        fechaActual = DateTime.Today;
        Puntajes punt = new Puntajes(fechaActual,Juego.Username,Juego.PuntajeActual);
        Juego.AgregarAPuntajes(punt);
       
        return View("Fin");
    }
      public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){

        Preguntas pregunta = Juego.ObtenerProximaPregunta(); 
        List<Respuestas> resp = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);

        if(Juego.VerificarRespuesta(idPregunta, idRespuesta)){
            ViewBag.RespuestaCorrecta = idRespuesta;
            ViewBag.RespuestaIncorrecta = -1;
            ViewBag.Resultado = "CORRECTO!";
        }
        else{
            ViewBag.Resultado = "INCORRECTO!";
            ViewBag.RespuestaIncorrecta = idRespuesta;
            foreach(Respuestas respu in resp){
                if(respu.Correcta == true){
                    ViewBag.RespuestaCorrecta = respu.IdRespuesta;
                }
            }
        }

        ViewBag.ContenidoRespuesta = resp;
        ViewBag.ContenidoPregunta = pregunta;
        ViewBag.FueRespondida = true;
        
        
        
        return View("Respuesta");
    }

     
       

         public IActionResult HighScores(){
            ViewBag.Puntajes = Juego.ObtenerPuntajesC();
            return View();
         }

      }





    

