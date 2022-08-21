using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;


    namespace TP7_PreguntadORT.Models{


        public static class BD{

             private static List <Categorias> _ListaCategorias = new List<Categorias>();
             private static List <Dificultades> _ListaDificultades = new List<Dificultades>();
            private static List <Preguntas> _ListaPreguntas = new List<Preguntas>();
            private static List <Respuestas> _ListaRespuestas = new List<Respuestas>();
            private static string _connectionString = @"Server=DESKTOP-P8MR2F6\SQLEXPRESS;
                  DataBase=PreguntadOrt;Trusted_Connection=True;";



            public static List <Categorias> ListarCategorias(){

                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Categorias";
                     _ListaCategorias = db.Query<Categorias>(sql).ToList();
                    }

                    return _ListaCategorias;

            }

                        public static List <Dificultades> ObtenerDificultades(){

                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Dificultades";
                     _ListaCategorias = db.Query<Categorias>(sql).ToList();
                    }

                    return _ListaDificultades;

            }

                    public static List <Preguntas> ObtenerPreguntas(int IdDificultad, int IdCategoria){

                    using(SqlConnection db = new SqlConnection(_connectionString)){
                    
                        string sql =  "SELECT * FROM Preguntas";
                        string connector = " where ";
                        if(IdDificultad != -1 ){
                             sql = sql + connector +  "IdDificultad = @IdDificultad";
                             connector = " and ";
                        }
                        if(IdCategoria != -1 ){
                             sql = sql + connector + "IdCategoria = @IdCategoria";
                        }

                         _ListaPreguntas = db.Query<Preguntas>(sql).ToList();
                    }

                    return _ListaPreguntas;


                       /*
                      if(IdDificultad != -1 && IdCategoria != -1){
                      sql = "SELECT * FROM Preguntas WHERE IdDificultad = @IdDificultad AND IdCategoria = @IdCategoria";
                      }else{
                        if(IdDificultad == -1 && IdCategoria != -1){
                             sql = "SELECT * FROM Preguntas WHERE IdCategoria = @IdCategoria";
                        }else{
                            if(IdDificultad != -1 && IdCategoria == -1){
                                 sql = "SELECT * FROM Preguntas WHERE IdDificultad = @IdDificultad";
                            }else{
                                 sql = "SELECT * FROM Preguntas";
                            }
                        }
                      }*/

                    }


                     
                    /*
                        
                    public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){

                        









                     }*/

        }
    }