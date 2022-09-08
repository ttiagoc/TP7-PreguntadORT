using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

          public class Puntajes{

            private int _idPuntaje;
            private string _username ="";
          
            private int _puntaje = 0;

            private DateTime _fecha = new DateTime();

             public Puntajes (DateTime pfecha, string pusername, int ppuntaje){

              
                _fecha = pfecha;
                _username = pusername;
                _puntaje = ppuntaje;



             }

            public Puntajes (){

              
                _fecha = new DateTime();
                _username = "no user";
                _puntaje = 0;



             }

            public string Username{
                   get{return _username;}
              set{_username = value;}
            }


          }

  }