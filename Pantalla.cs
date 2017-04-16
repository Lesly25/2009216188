using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009216188
{

    public class Pantalla
    {



        public void MostrarMensaje(string mensaje)
        {

            Console.Write(mensaje);

        }

        public void WriteLine(string mensaje)
        {

            Console.WriteLine(mensaje);
        }

        public void MostrarMontoEnSoles(decimal monto)
        {
            Console.Write("{0:C}", monto);
        }
    }
}