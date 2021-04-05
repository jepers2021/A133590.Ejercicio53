using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace A133590.Ejercicio53
{
    [Serializable]
    class Agenda
    {
        List<Contacto> contactos;
        

        public Agenda()
        {
            contactos = new List<Contacto>();
        }

        public void AgregarContacto(string nombre, string apellido, string telefono)
        {
            foreach(char c in telefono)
            {
                if(!Char.IsDigit(c))
                {
                    Console.WriteLine("Formato de teléfono incorrecto.");
                    return;
                }
            }

            foreach(Contacto c in contactos)
            {
                if(c.Nombre.Equals(nombre) && c.Apellido.Equals(apellido) && c.Telefono.Equals(telefono))
                {
                    Console.WriteLine("Contacto ya existente en la agenda.");
                    return;
                }
            }

            contactos.Add(new Contacto(nombre, apellido, telefono));
            Console.WriteLine("Contacto agregado exitosamente.");
        }

        public void BuscarPorApellido(string apellido)
        {
            bool encontrado = false;
            foreach(Contacto c in contactos)
            {
                if(c.Apellido.Equals(apellido, StringComparison.InvariantCultureIgnoreCase))
                {
                    encontrado = true;
                    Console.WriteLine($"Contacto encontrado, Nombre: {c.Nombre}, Apellido: {c.Apellido}, Teléfono: {c.Telefono}");
                }
            }

            if(!encontrado)
            {
                Console.WriteLine($"No se encontró contacto con apellido: {apellido}");
            }
        }

        public void BuscarPorNombre(string nombre)
        {
            bool encontrado = false;
            foreach (Contacto c in contactos)
            {
                if (c.Nombre.Equals(nombre, StringComparison.InvariantCultureIgnoreCase))
                {
                    encontrado = true;
                    Console.WriteLine($"Contacto encontrado, Nombre: {c.Nombre}, Apellido: {c.Apellido}, Teléfono: {c.Telefono}");
                }
            }
            if (!encontrado)
            {
                Console.WriteLine($"No se encontró contacto con nombre: {nombre}");
            }
        }
    }
}
