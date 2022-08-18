using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP7_PreguntadORT.Models

  {

        public class Respuestas{

             private int _idRespuesta;
            private int _idPregunta;
            private int _opcion;
            private string _contenido ="";
            private bool  _correcta;
            private string _foto ="";




            public Respuestas (int pidRespuesta, int pidPregunta, int popcion, string pcontenido, bool pcorrecta, string pfoto){

                _idRespuesta = pidRespuesta;
                _idPregunta = pidPregunta;
                _opcion = popcion;
                _contenido = pcontenido;
                _correcta = pcorrecta;
                _foto = pfoto;


             }


             public int IdRespuesta{
                
              get{return _idRespuesta;}
              set{_idRespuesta = value;}
            }
            
            public int IdPregunta{
                
              get{return _idPregunta;}
              set{_idPregunta = value;}
            }
            
            public int Opcion{
                
              get{return _opcion;}
              set{_opcion = value;}
            }

              public string Contenido{
                
              get{return _contenido;}
              set{_contenido = value;}
            }

             public bool Correcta{
                
              get{return _correcta;}
              set{_correcta = value;}
            }

            public string Foto{
                
              get{return _foto;}
              set{_foto = value;}
            }




        }






















  }