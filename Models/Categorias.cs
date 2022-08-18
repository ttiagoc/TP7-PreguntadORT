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


            public Categorias (int pidCategoria, string pnombre, string pfoto){

                _idCategoria = pidCategoria;
                _nombre = pnombre;
                _foto = pfoto;



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