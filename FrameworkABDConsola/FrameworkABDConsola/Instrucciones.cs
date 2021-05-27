using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkABDConsola
{
    class Instrucciones
    {
        public void Impresion()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("El comando se espera en el siguiente formato");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Salvar o recuperar la base de datos o todas las tablas de la base nombrada al archivo nombrado");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SALVAR\\RECUPERAR BASE\\TABLA [NOMBRE DE BASE DE DATOS] A\\DE [NOMBRE DE ARCHIVO]");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Salvar o recuperar las bases de datos nombradas al archivo nombrado");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("SALVAR\\RECUPERAR BASES [NOMBRE,NOMBRE,NOMBRE,...] A\\DE [NOMBRE DE ARCHIVO]");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Salvar o recuperar las tablas nombradas de la base nombrada al archivo nombrado");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("SALVAR\\RECUPERAR TABLAS [BASE DE DATOS] [NOMBRE, NOMBRE, NOMBRE, ...] A\\DE [NOMBRE DE ARCHIVO]");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

        }
        

    }
}
