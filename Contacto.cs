using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace A133590.Ejercicio53
{
    [Serializable]
    class Contacto
    {
        string nombre;
        string apellido;
        string telefono;

        public Contacto(string nombre, string apellido, string telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        public string Nombre { get => nombre; }
        public string Apellido { get => apellido; }
        public string Telefono { get => telefono; }
    }
}
