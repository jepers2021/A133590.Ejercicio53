using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace A133590.Ejercicio53
{
    class Program
    {
        private static string ruta = "contactos.dat";
        static void GrabarAgenda(Agenda agenda)
        {
            FileStream fs = new FileStream(ruta, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, agenda);
                Console.WriteLine($"Agenda grabada exitosamente en {Path.GetFullPath(ruta)}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Fallo al serializar. Razón: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void LeerAgenda(ref Agenda agenda)
        {
            if (File.Exists(ruta))
            {
                FileStream fs = new FileStream(ruta, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    // Deserialize the hashtable from the file and
                    // assign the reference to the local variable.
                    agenda = (Agenda)formatter.Deserialize(fs);
                    Console.WriteLine($"Agenda leida exitosamente de {Path.GetFullPath(ruta)}");
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Fallo al serializar. Razón: " + e.Message);
                    agenda = new Agenda();
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Console.WriteLine("Archivo no encontrado.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 53");


            Agenda agenda = new Agenda();

            while(true)
            {
                int opcion;
                Console.WriteLine("1) Agregar contacto a la agenda.");
                Console.WriteLine("2) Buscar contacto por apellido");
                Console.WriteLine("3) Buscar contacto por nombre");
                Console.WriteLine("4) Grabar agenda en memoria");
                Console.WriteLine("5) Leer agenda de memoria");
                Console.WriteLine("6) Finalizar");
                Console.Write("Ingrese su opción: ");
                bool exito = Int32.TryParse(Console.ReadLine(), out opcion);
                while(!exito || opcion < 1 || opcion > 6 )
                {
                    Console.WriteLine("Opción inválida.");
                    Console.Write("Ingrese su opción: ");
                    exito = Int32.TryParse(Console.ReadLine(), out opcion);
                }
                Console.Clear();
                switch(opcion)
                {
                    case 1:
                        {
                            
                            Console.Write("Ingrese nombre de contacto: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese apellido: ");
                            string apellido = Console.ReadLine();
                            Console.Write("Ingrese telefono: ");
                            string telefono = Console.ReadLine();


                            agenda.AgregarContacto(nombre, apellido, telefono);
                        }
                        
                        
                        break;
                    case 2:
                        {
                            Console.Write("Ingrese apellido: ");
                            string apellido = Console.ReadLine();
                            agenda.BuscarPorApellido(apellido);
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Ingrese nombre: ");
                            string nombre = Console.ReadLine();
                            agenda.BuscarPorNombre(nombre);
                        }
                        break;
                    case 4:
                        GrabarAgenda(agenda);
                        break;
                    case 5:
                        LeerAgenda(ref agenda);
                        break;
                    case 6:
                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                }
            }

        }
    }
}
