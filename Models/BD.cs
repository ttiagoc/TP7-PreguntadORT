using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;


    namespace TP7_PreguntadORT.Models{


        public static class BD{

             
            
           
            private static string _connectionString = @"Server=A-PHZ2-CIDI-029;
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
                    // string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pIdDificultad AND IdCategoria = @pIdCategoria";   
                    
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
        }
    }