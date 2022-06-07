using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArchivosBinarios
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia de la clase ClaseArchivo
            ClaseArchivoBinario escritura = new ClaseArchivoBinario();

            //Declaracion de variables auxiliares
            string Archi = null;
            char opc;

            
            do
            {
                Console.Clear();
                Console.WriteLine("BIENVENIDO AL MENU DE LA GESTION DE EMPLEADOS");

                Console.WriteLine("Indica que es lo que quieres hacer...");

                Console.WriteLine("1) Capturar empleados.");
                Console.WriteLine("2) Mostrar empleados. ");
                Console.WriteLine("3) Salir del programa. ");
                opc = Console.ReadKey().KeyChar;

                switch (opc)
                {
                    case '1':
                        //Escritura
                        try
                        {
                            Console.WriteLine("Indica como quieres llamar a tu archivo: ");
                            Archi = Console.ReadLine();

                            char resp = 's';
                            if (File.Exists(Archi + ".txt"))
                            {
                                Console.Write("El archivo existe, quieres sobreescribirlo? (s/n)");
                                resp = Console.ReadKey().KeyChar;
                            }
                            if((resp=='s')||(resp == 'S'))
                                escritura.CrearArchivo(Archi + ".txt");

                        }catch(Exception e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;


                    case '2':
                        //Lectura
                        try
                        {
                            Console.WriteLine("Indica como se llama el achivo que quieres leer: ");
                            Archi = Console.ReadLine();
                            escritura.MostrarArchivo(Archi + ".txt");
                        }catch(Exception e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Nos vemos!!!");
                        Console.ReadKey();
                        break;


                    default:
                        Console.WriteLine("Esa opcion no es valida...");
                        break;

                }
            } while (opc != '3');


            
        }
    }
}
