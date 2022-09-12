using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Timers;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;

  namespace TP7_PreguntadORT.Models

  {

    public static class Juego{

       private static string _username = "null";
       private static int _puntajeActual = 0;
       private static int _cantidadPreguntasCorrectas = 0;
       private static List<Preguntas> _preguntas = new List<Preguntas>();
       private static List<Respuestas> _respuestas = new List<Respuestas>();

        private static List<Preguntas> _preguntasSinMezclar = new List<Preguntas>();


        private static System.Timers.Timer _reloj;        
        private static int _segundos = 0;


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



    
        public static int Segundos{
            get{
                return _segundos;
            }
        }
        public static void InicializarJuego(){

             _username = "";
             _puntajeActual = 0;
             _cantidadPreguntasCorrectas = 0;
             _preguntas.Clear();
             _respuestas.Clear();
             _segundos = 0;
            
        }

        public static List<Categorias> ObtenerCategorias(){
          return BD.ListarCategorias();
        }

        public static List<Dificultades> ObtenerDificultades(){
          return BD.ObtenerDificultades();
        }
        
        
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


        public static List<Puntajes> ObtenerPuntajesC(){
          return BD.ObtenerPuntajes();
        }




        public static void FinalizarTimer(){
            _reloj.Stop();
            _reloj.Dispose();
         
        }

        public static void ComenzarTimer()
        {                   
            _reloj = new System.Timers.Timer(1000);
            // Definimos el evento que se dispara al finalizar cada intervalo de tiempo 
            _reloj.Elapsed += Tick;
            _reloj.AutoReset = true;
            _reloj.Enabled = true;
        }        

        public static void Tick(Object source, ElapsedEventArgs e)
        {
            _segundos++;            
        }   
    }


  }