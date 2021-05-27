using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FrameworkABDConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Instrucciones inst = new Instrucciones();
            bool loop = true;
            Console.WriteLine("servidor : LOCALHOST");
            Console.Write("Id usuario : ");
            string uid = Console.ReadLine();
            Console.Write("contraseña : ");
            string pwd = Console.ReadLine();
            Console.Clear();
            inst.Impresion();
            while (loop)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando comando...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string comando = Console.ReadLine();
                    Interprete inter = new Interprete();
                    inter.inter(uid, pwd, comando);



                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            
            
        }
        
    }
}
