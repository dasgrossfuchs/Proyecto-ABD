using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FrameworkABDConsola
{
    class Interprete
    {
        public void inter(string uid, string pwd, string comando)
        {
            string[] tablas;
            List<string> tab = new List<string>();
            
            tab.Clear();
            string[] palabras = comando.Split(' ');
            switch (palabras[0].ToLower())
            {
                case "salvar":
                    switch (palabras[1].ToLower())
                    {
                        case "base":
                                //SALVAR BASE dbname A ARCHIVO
                                Backup(uid,pwd,palabras[2],palabras[4]);
                                //backup de todas las bases de datos al archivo
                            break;
                        case "bases":
                                //SALVAR BASE NOMBRE,NOMBRE,NOMBRE A ARCHIVO
                                string[] nombres = palabras[2].Split(',');
                                string archivo = palabras[4];

                                for (int i = 0; i < nombres.Length; i++)
                                {
                                    Backup(uid, pwd, nombres[i], archivo + (i+1));
                                }
                                Console.WriteLine("Bases salvadas!");
                                Console.WriteLine("Salvadas en "+archivo+"1..."+nombres.Length);
                                //backup de todas las bases de datos que conforman a nombres al archivo
                            break;
                        case "tabla":
                            //SALVAR TABLA DBNAME A ARCHIVO
                            tablas = palabras[3].Split(',');
                            TableBu(uid, pwd, palabras[2], palabras[4], tab);
                            Console.WriteLine("Tablas guardadas exitosamente como \"" + palabras[4] + ".sql\"");
                            //backup de todas las tablas de la base de datos nombrada dbname al archivo

                            break;
                        case "tablas":

                                //SALVAR TABLA DBNAME TABLA,TABLA,TABLA A ARCHIVO
                            tablas = palabras[3].Split(',');
                            foreach (string item in tablas)
                            {
                                tab.Add(item);
                            }
                            TableBu(uid, pwd, palabras[2], palabras[5], tab);
                            Console.WriteLine("Tablas guardadas exitosamente como \""+palabras[5]+".sql\"");
                            //backup de las tablas nombradas en la base de datos dbname al archivo
                                
                            

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
                                //RECUPERAR BASE dbname DE ARCHIVO
                                Restore(uid, pwd, palabras[2], palabras[4]);
                                //recuperacion de todas las bases de datos desde archivo
                                break;
                        case "bases":

                            //RECUPERAR BASE NOMBRE,NOMBRE,NOMBRE DE ARCHIVO
                            string[] nombres = palabras[2].Split(',');
                            string archivo = palabras[4];

                            for (int i = 0; i < nombres.Length; i++)
                            {
                                Restore(uid, pwd, nombres[i], archivo + (i + 1));
                            }
                            Console.WriteLine("Bases salvadas!");
                            Console.WriteLine("Salvadas en " + archivo + "1..." + nombres.Length);

                            //recuperacion de todas las bases de datos que conforman a nombres desde archivo

                            break;
                        case "tabla":
                            //RECUPERAR TABLA DBNAME DE ARCHIVO
                            Restore(uid, pwd, palabras[2], palabras[4]);
                            //recuperacion de todas las tablas de la base de datos nombrada dbname desde archivo
                            
                            break;
                        case "tablas":
                            Restore(uid, pwd, palabras[2], palabras[4]);

                            break;
                        default:
                            Console.WriteLine("Error procesando comando en:\'" + palabras[1].ToUpper() + "\'");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Error procesando comando en:\'" + palabras[0].ToUpper() + "\'");
                    break;
                case "salir":

                    break;
            }
        }
        public void Backup(string uid, string pwd, string db, string ruta)
        {
            string file = db + ".sql";
            string constring = "server=localhost;uid=" + uid + ";pwd=" + pwd + ";database=" + db+";";
            string[] extension = ruta.Split('.');
            if (extension.Length != 2 || extension[1] != "sql")
            {
                file = extension[0] + ".sql";
            }
            else
            {
                file = ruta;
            }
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        
                        cmd.Connection = conn;
                        conn.Open();

                        Console.WriteLine("Conexion establecida");
                        mb.ExportToFile(file);
                        Console.WriteLine("guardado como : " + file);
                        conn.Close();
                        Console.WriteLine("Conexion finalizada");
                    }
                }
            }
        }
        public void Restore(string uid, string pwd, string db, string ruta)
        {
            string file = db + ".sql";
            string constring = "server=localhost;uid=" + uid + ";pwd=" + pwd + ";database=" + db+";";
            string[] extension = ruta.Split('.');
            if (extension.Length != 2 || extension[1] != "sql")
            {
                file = extension[0] + ".sql";
            }
            else
            {
                file = ruta;
            }
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        Console.WriteLine("Conexion establecida");
                        mb.ImportFromFile(file);
                        Console.WriteLine("Importado de : " + file);
                        conn.Close();
                        Console.WriteLine("Conexion finalizada");
                    }
                }
            }
        }

        public void TableBu(string uid, string pwd, string db, string ruta,List <string> tablas)
        {
            string file = db + ".sql";
            string constring = "server=localhost;uid=" + uid + ";pwd=" + pwd + ";database=" + db + ";";
            string[] extension = ruta.Split('.');
            if (extension.Length != 2 || extension[1] != "sql")
            {
                file = extension[0] + ".sql";
            }
            else
            {
                file = ruta;
            }
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportInfo.TablesToBeExportedList = tablas;
                        mb.ExportToFile(file);
                    }
                }
            }
        }
    }
}
