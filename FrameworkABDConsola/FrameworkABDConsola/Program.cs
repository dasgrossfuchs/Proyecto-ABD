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
            MySqlConnection conn;
            Console.WriteLine("servidor : LOCALHOST");
            Console.Write("Id usuario : ");
            string uid = Console.ReadLine();
            Console.Write("contraseña : ");
            string pwd = Console.ReadLine();
            string constr = "server=localhost; uid="+uid+";pwd="+pwd+";database=sakila";
            try
            {
                conn = new MySqlConnection(constr);
                conn.Open();
                Console.WriteLine("Conexión exitosa!");
                mysqlback
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
            
        }
    }
}
