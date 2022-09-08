using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

    public static class Juego{

       private static string _username = "null";
       private static int _puntajeActual = 0;
       private static int _cantidadPreguntasCorrectas = 0;
       private static List<Preguntas> _preguntas = new List<Preguntas>();
       private static List<Respuestas> _respuestas = new List<Respuestas>();

        private static List<Preguntas> _preguntasSinMezclar = new List<Preguntas>();


         public static string Username{
                
              get{return _username;}
              
            }

         public static int PuntajeActual{
                
              get{return _puntajeActual;}
             
            }

         public static int CantidadPreguntasCorrectas{
                
              get{return _cantidadPreguntasCorrectas;}
             
            }

        public static List<Preguntas> Preguntas{
                
              get{return _preguntas;}
             
            }

        public static List<Respuestas> Respuestas{
                
              get{return _respuestas;}
             
            }


        public static void InicializarJuego(){

             _username = "";
             _puntajeActual = 0;
             _cantidadPreguntasCorrectas = 0;
             _preguntas.Clear();
             _respuestas.Clear();
            
        }

        public static List<Categorias> ObtenerCategorias(){
          return BD.ListarCategorias();
        }

        public static List<Dificultades> ObtenerDificultades(){
          return BD.ObtenerDificultades();
        }
        /*
        public static void CargarPartida(string username, int dificultad, int categoria){
          _username = username;
         _preguntas = BD.ObtenerPreguntas(dificultad,categoria);
         _respuestas = BD.ObtenerRespuestas(_preguntas);

        }

         */

          public static void CargarPartida(string username, int dificultad, int categoria){

            Random random = new Random();       
            int rnd;
                 
            _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
            int cant = _preguntas.Count();

            for(int i = 0; i < cant; i++){
                rnd = random.Next(0,cant);
                Preguntas temporal = _preguntas[rnd];
                _preguntas[rnd] = _preguntas[i];
                _preguntas[i] = temporal;         
            }            
            _respuestas = BD.ObtenerRespuestas(_preguntas);   
            _username = username;

        }

/*        public static Preguntas ObtenerProximaPregunta(){

          int cant = _preguntas.Count();
          Random random = new Random();
          int rnd = random.Next(0,cant);

          if (_preguntas.Count() != 0)
          {
           Preguntas aux = _preguntas[rnd];
         // _preguntas.Remove(aux);
          return aux;   
             
          }else{
            return null;
          }

          */

           public static Preguntas ObtenerProximaPregunta(){            

            if(_preguntas.Count() != 0){
               return _preguntas[0];   
            }
                    
              return null;
        }
        
        

        public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){

          List<Respuestas> listaProximasRespuestas = new List<Respuestas>();

          foreach (Respuestas res in _respuestas)
          {
            
            if (res.IdPregunta == idPregunta)
            {
              listaProximasRespuestas.Add(res);
            }

          }
           
           return listaProximasRespuestas;

        }

        public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
            
              for(int i = 0; i < _preguntas.Count();i++){
                if(_preguntas[i].IdPregunta == idPregunta){
                    _preguntas.RemoveAt(i);
                }
            }
                        
            foreach(Respuestas resp in _respuestas){
                if(resp.IdRespuesta == idRespuesta){
                    if(resp.Correcta == true){

                        _puntajeActual += 50;
                        _cantidadPreguntasCorrectas++;                                         

                        return true;
                    }                    
                }
            }
            
            return false;            

        }

        public static void AgregarAPuntajes(Puntajes punt){
          BD.AgregarPuntaje(punt);
        }


        public static List<Puntajes> ObtenerPuntajes(){
          return BD.ObtenerPuntajes();
        }

    }


  }