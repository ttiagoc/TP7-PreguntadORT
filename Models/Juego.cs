using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

    public class Juego{

       private static string _username = "";
       private static int _puntajeActual;
       private static int _cantidadPreguntasCorrectas;
       private static List<Preguntas> _preguntas;
       private static List<Respuestas> _respuestas;


         public string Username{
                
              get{return _username;}
              
            }

         public int PuntajeActual{
                
              get{return _puntajeActual;}
             
            }

         public int CantidadPreguntasCorrectas{
                
              get{return _cantidadPreguntasCorrectas;}
             
            }

        public List<Preguntas> Preguntas{
                
              get{return _preguntas;}
             
            }

        public List<Respuestas> Respuestas{
                
              get{return _respuestas;}
             
            }


    }


  }