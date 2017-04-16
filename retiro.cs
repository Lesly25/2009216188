using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009216188
{
    public class Retiro
    {
        private decimal monto;
        private Teclado teclado;
        private DispensadorEfectivo dispensadorEfectivo;
        private const int Cancelo = 6;



        public Retiro(int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatos baseDatosATM, Teclado tecladoATM, DispensadorEfectivo dispensadorEfectivoATM) : base(numeroCuentaUsuario, pantallaATM, baseDatosATM)
        {
            teclado tecladoATM;
            dispensadorEfectivo dispensadorEfectivoATM;

        }

        public override void Ejecutar()
        {
            bool Suficientefectivo = false;
            bool transaccionCancelada = false;


            do
            {
                int seleccion = MostrarMenuDeMontos();
                if (seleccion != Cancelo)
                {
                    monto = seleccion;
                    decimal saldoDisponible = BaseDatos.ObtenerSaldoDisponible(NumerCuenta);



                    if (monto <= saldoDisponible)
                    {
                        if (dispensadorEfectivo.SuficienteEfectivo(monto))
                            BaseDatos.Debitar(numeroCuenta, monto);
                        dispensadorEfectivo.DispensadorEfectivo(monto);
                        Suficientefectivo = true;

                        Console.WriteLine(" No hay suficiente efectivo disponible en el ATM. " + "\n\n Elija un monto mas pequeño.");
                    }
                    else
                        Console.WriteLine(" No hay suficiente efectivo disponible en su cuenta. " + " \n\n Elija un monto mas pequeño.");
                }
                else
                {
                    Console.WriteLine(" Cancelando Transaccion  ");
                    transaccionCancelada = true;
                }

            } while ((!Suficientefectivo) && (!transaccionCancelada));
        }

        private int MostrarMenuDeMontos()
        {
            int eleccionUsuario = 0;

            int[] montos = { 0, 20, 40, 50, 100, 200 };


            while (eleccionUsuario == 0)
            {
                // muestra menú
                Console.WriteLine(" \n Opciones de Retiro");
                Console.WriteLine(" 1 - S/.20 ");
                Console.WriteLine(" 2 - S/.40 ");
                Console.WriteLine(" 3 - S/.50 ");
                Console.WriteLine(" 4 - S/.100 ");
                Console.WriteLine(" 5 - S/.200 ");
                Console.WriteLine(" 6- Cancelar trasaccion");

                Console.WriteLine(" \n Elija una Opción  de Retiro (1-6): ");

                int entrada = teclado.ObtenerEntrada();

                switch (entrada)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        eleccionUsuario = montos[entrada];
                        break;
                    case Cancelo:
                        eleccionUsuario = Cancelo;
                        break;
                    default:

                        Console.WriteLine(" \n Selección inválida, Intente de nuevo");
                        break;
                }
            }


            return eleccionUsuario;
        }
    }

        

        
}

                

