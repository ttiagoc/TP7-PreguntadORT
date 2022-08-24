using System.Diagnostics;
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

        return RedirectToAction("Jugar" , "Home", new {username = username, dificultad = dificultad, categoria = categoria});
    }

    public IActionResult Jugar(){
      if(Juego.ObtenerProximaPregunta != null)
      {
            Preguntas pregunta = Juego.ObtenerProximaPregunta();


          ViewBag.ContenidoPregunta = pregunta;
          ViewBag.ContenidoRespuesta = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
      
            return View("Juego");
      }else
      {
        return View("Fin");
      }

      [HttpPost] IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){

            bool Sicorrect = Juego.VerificarRespuesta(idPregunta,idRespuesta);
            ViewBag.SiEsCorrecta = Sicorrect;
            
            return View("Respuesta");


            }



      }





    }


