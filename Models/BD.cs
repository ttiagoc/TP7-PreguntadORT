using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;


    namespace TP7_PreguntadORT.Models{


        public static class BD{

             
            
           
            private static string _connectionString = @"Server=A-PHZ2-CEO-005;
                  DataBase=PreguntadOrt;Trusted_Connection=True;";



            public static List <Categorias> ListarCategorias(){
                     List <Categorias> _ListaCategorias = new List<Categorias>();
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Categorias";
                     _ListaCategorias = db.Query<Categorias>(sql).ToList();
                    }

                    return _ListaCategorias;

            }

                 public static List <Dificultades> ObtenerDificultades(){
                     List <Dificultades> _ListaDificultades = new List<Dificultades>();
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Dificultades";
                     _ListaDificultades = db.Query<Dificultades>(sql).ToList();
                    }

                    return _ListaDificultades;

            }

                    public static List <Preguntas> ObtenerPreguntas(int dificultad, int categoria){
                    
                    List<Preguntas> _ListaPreguntas = new List<Preguntas>();
                   
                    
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                     
                        string sql =  "SELECT * FROM Preguntas";
                        string connector = " where ";
                        if(dificultad != -1 ){
                             sql = sql + connector +  "IdDificultad = @pIdDificultad";
                             connector = " and ";
                        }
                        if(categoria != -1 ){
                             sql = sql + connector + "IdCategoria = @pIdCategoria";
                        }
                         
                        _ListaPreguntas = db.Query<Preguntas>(sql, new{pIdDificultad = dificultad, pIdCategoria = categoria}).ToList();
                    }

                    return _ListaPreguntas;

                    }


                     /*
                   public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){

                     List<Respuestas> listaRespuestas = new List<Respuestas>();

                     foreach(Preguntas preg in preguntas){

                          string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                         using(SqlConnection db = new SqlConnection(_connectionString)){
                         listaRespuestas = db.Query<Respuestas>(SQL, new{pIdPregunta = preg.IdPregunta}).ToList();
                      }
                }
                          return listaRespuestas;
        }
        */
        
        public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){
        
            List<Respuestas> listaRespuestas = new List<Respuestas>();
            
            foreach(Preguntas preg in preguntas){
                string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                using(SqlConnection db = new SqlConnection(_connectionString)){
                    listaRespuestas.AddRange(db.Query<Respuestas>(SQL, new{pIdPregunta = preg.IdPregunta}));
                }
            }
            return listaRespuestas;
        }
        
        public static void AgregarPuntaje(Puntajes punt){

              string SQL = "INSERT INTO Puntajes(fecha,username,puntaje,segundos) VALUES (@pfecha, @pusername, @ppuntaje, @psegundos)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pfecha = punt.Fecha, pusername = punt.Username, ppuntaje = punt.Puntaje, psegundos = punt.Segundos} );
                }

                  

            }



             public static List <Puntajes> ObtenerPuntajes(){
                     List <Puntajes> _ListaPuntajes = new List<Puntajes>();
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "select * from Puntajes order by puntaje desc, segundos";
                     _ListaPuntajes = db.Query<Puntajes>(sql).ToList();
                    }

                    return _ListaPuntajes;

            }






        }
    }