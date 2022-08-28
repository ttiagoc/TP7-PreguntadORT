using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

        public class Categorias{

            private int _idCategoria;
            private string _nombre ="";
            private string _foto ="";


            public Categorias (string pnombre, string pfoto){

              
                _nombre = pnombre;
                _foto = pfoto;



             }


             public Categorias (){

              
                _nombre = "";
                _foto = "";



             }

            public int IdCategoria{
                
              get{return _idCategoria;}
              set{_idCategoria = value;}
            }

              public string Nombre{
                
              get{return _nombre;}
              set{_nombre = value;}
            }

             public string Foto{
                
              get{return _foto;}
              set{_foto = value;}
            }






        }






















  }