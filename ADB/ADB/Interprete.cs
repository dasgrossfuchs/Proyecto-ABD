using System;
using System.Collections.Generic;
using System.Text;

namespace ADB
{
    class Interprete
    {
        public void inicio(string comando)//cambiar esto a string, que todos los caminos regresen la instruccion correspondiente
        {
            string[] palabras = comando.Split(' ');
            switch (palabras[0].ToLower())
            {
                case "salvar":
                    switch (palabras[1].ToLower())
                    {
                        case "base":
                            if (palabras.Length == 4)
                            {
                                //SALVAR BASE A ARCHIVO
                                string archivo = palabras[3];

                                //backup de todas las bases de datos al archivo
                            }
                            else 
                            {
                                //SALVAR BASE NOMBRE,NOMBRE,NOMBRE A ARCHIVO
                                string[] nombres = palabras[2].Split(',');
                                string archivo = palabras[4];

                                //backup de todas las bases de datos que conforman a nombres al archivo
                            }
                            break;
                        case "tabla":
                            if (palabras.Length == 5)
                            {
                                //SALVAR TABLA DBNAME A ARCHIVO
                                string dbname = palabras[2];
                                string archivo = palabras[3];

                                //backup de todas las tablas de la base de datos nombrada dbname al archivo
                            }
                            else
                            {
                                //SALVAR TABLA DBNAME TABLA,TABLA,TABLA A ARCHIVO
                                string dbname = palabras[2];
                                string[] tablas = palabras[3].Split(',');
                                string archivo = palabras[5];
                                foreach (var item in tablas)
                                {
                                    //backup de las tablas nombradas en la base de datos dbname al archivo
                                }
                            }

                            break;
                        default:
                            Console.WriteLine("Error procesando comando en:\'" + palabras[1].ToUpper() + "\'");
                            break;
                    }
                    break;
                case "recuperar":
                    switch (palabras[1].ToLower())
                    {
                        case "base":
                            if (palabras.Length == 4)
                            {
                                //RECUPERAR BASE DE ARCHIVO
                                string archivo = palabras[3];

                                //recuperacion de todas las bases de datos desde archivo
                            }
                            else
                            {
                                //RECUPERAR BASE NOMBRE,NOMBRE,NOMBRE DE ARCHIVO
                                string[] nombres = palabras[2].Split(',');
                                string archivo = palabras[4];

                                //recuperacion de todas las bases de datos que conforman a nombres desde archivo
                            }
                            break;
                        case "tabla":
                            if (palabras.Length == 5)
                            {
                                //RECUPERAR TABLA DBNAME DE ARCHIVO
                                string dbname = palabras[2];
                                string archivo = palabras[3];

                                //recuperacion de todas las tablas de la base de datos nombrada dbname desde archivo
                            }
                            else
                            {
                                //RECUPERAR TABLA DBNAME TABLA,TABLA,TABLA DE ARCHIVO
                                string dbname = palabras[2];
                                string[] tablas = palabras[3].Split(',');
                                string archivo = palabras[5];
                                foreach (var item in tablas)
                                {
                                    //recuperacion de las tablas nombradas en la base de datos dbname desde archivo
                                }
                            }

                            break;
                        default:
                            Console.WriteLine("Error procesando comando en:\'" + palabras[1].ToUpper() + "\'");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Error procesando comando en:\'"+palabras[0].ToUpper() + "\'");
                    break;

            }
        }
    }
}
