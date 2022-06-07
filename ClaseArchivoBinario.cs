using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArchivosBinarios
{
    class ClaseArchivoBinario
    {
        //declaracion de flujos
        BinaryWriter bw = null; //flujo salida - escritura de datos
        BinaryReader br = null; //flujo entrada - lectura de datos

        //campos
        string Nombre, Direccion;
        long Telefono;
        int NumEmp, DiasTrabajados;
        float SalarioDiario;

        public void CrearArchivo(string Archivo)
        {
            //variable local metodo
            char resp;

            try
            {
                //Creacion del flujo para escribir datos al archivo

                bw = new BinaryWriter(new FileStream(Archivo, FileMode.Create, FileAccess.Write));

                do
                {
                    Console.Clear();
                    Console.Write("Indica el numero del empleado: ");
                    NumEmp = int.Parse(Console.ReadLine());

                    Console.Write("Indica el nombre del empleado: ");
                    Nombre = Console.ReadLine();

                    Console.Write("Indica la direccion del empleado: ");
                    Direccion = Console.ReadLine();

                    Console.Write("Indica el telefono del empleado: ");
                    Telefono = long.Parse(Console.ReadLine());

                    Console.Write("Indica los dias que ha trabajado el empleado: ");
                    DiasTrabajados = int.Parse
                        (Console.ReadLine());

                    Console.Write("Indica el salario diario del empleado: ");
                    SalarioDiario = float.Parse(Console.ReadLine());

                    //Escritura de los datos en el archivo
                    bw.Write(NumEmp);
                    bw.Write(Nombre);
                    bw.Write(Direccion);
                    bw.Write(Telefono);
                    bw.Write(DiasTrabajados);
                    bw.Write(SalarioDiario);




                    Console.Write("Desea seguir capturando? (s/n)");
                    resp = Console.ReadKey().KeyChar;
                } while (resp == 's' || resp == 'S');
            }catch(Exception e)
            {
                Console.WriteLine("\nError: " + e.Message);
                Console.WriteLine("\nRuta: " + e.StackTrace);
            }
            finally
            {
                if (bw != null)
                    bw.Close(); //Cierra el flujo - escritura

                Console.Write("\nPresione cualquier tecla para terminar la escritura y regresar al menu.");
                Console.ReadKey();
            }
        }

        public void MostrarArchivo(string Archivo)
        {
            try
            {
                //Verifica si existe el archivo
                if (File.Exists(Archivo))
                {
                    //crea un flujo para leer datos del archivo
                    br = new BinaryReader(new FileStream(Archivo, FileMode.Open, FileAccess.Read));

                    //Despliegue de datos en pantalla
                    Console.Clear();

                    do
                    {
                        //lectura de registros mientras no llegue a EndOfFile

                        NumEmp = br.ReadInt32();

                        Nombre = br.ReadString();

                        Direccion = br.ReadString();

                        Telefono = br.ReadInt64();

                        DiasTrabajados = br.ReadInt32();

                        SalarioDiario = br.ReadInt32();

                        //muestra los datos

                        Console.WriteLine("Numero del empleado: " + NumEmp);

                        Console.WriteLine("Nombre dle empleado: " + Nombre);

                        Console.WriteLine("Direccion del empleado: " + Direccion);

                        Console.WriteLine("Telefono del empleado: " + Telefono);

                        Console.WriteLine("Dias trabajados: " + DiasTrabajados);

                        Console.WriteLine("Salario diario del empleado: {0,C}", SalarioDiario);

                        Console.WriteLine("SUELDO TOTAL del empleado: {0,C}", (DiasTrabajados * SalarioDiario));

                        Console.WriteLine("\n");

                    }while (true);
                
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\nEl archivo " + Archivo + " NO existe en el disco...");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            catch(EndOfStreamException)
            {
                Console.WriteLine("\n\nFin del listado de empleados");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            finally
            {
                if (br != null)
                    br.Close(); //Cierre del flujo
                Console.WriteLine("Presione cualquier tecla para terminar la lectura de datos y regresar al menu.");
                Console.ReadKey();
            }
        }

        ~ClaseArchivoBinario()
        {
            Console.WriteLine("Memoria Liberada Clase Archivo Binario");
        }
    }
}
