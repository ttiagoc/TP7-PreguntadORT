using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

        public class Dificultades{

            private int _idDificultad;
            private string _nombre ="";


            public Dificultades (int pidDificultad, string pnombre){

                _idDificultad = pidDificultad;
                _nombre = pnombre;
                
             }




            public int IdDificultad{
                
              get{return _idDificultad;}
              set{_idDificultad = value;}
            }

              public string Nombre{
                
              get{return _nombre;}
              set{_nombre = value;}
            }

            






        }






















  }