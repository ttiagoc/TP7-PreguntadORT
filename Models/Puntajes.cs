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

            private int _segundos = 0;
             public Puntajes (DateTime pfecha, string pusername, int ppuntaje, int psegundos){

              
                _fecha = pfecha;
                _username = pusername;
                _puntaje = ppuntaje;
                _segundos = psegundos;


             }

            public Puntajes (){

              
                _fecha = new DateTime();
                _username = "no user";
                _puntaje = 0;



             }

                 public int IdPuntaje{
                   get{return _idPuntaje;}
              set{_idPuntaje = value;}
            }



            public string Username{
                   get{return _username;}
              set{_username = value;}
            }


            public DateTime Fecha{
                get{return _fecha;}
                set{_fecha = value;}
            }

              public int Puntaje{
                get{return _puntaje;}
                set{_puntaje = value;}
            }

            public int Segundos{
                   get{return _segundos;}
              set{_segundos = value;}
            }

            

          }

  }