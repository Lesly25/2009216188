using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009216188
{
    public class ATM {

        private bool usuarioAutenticado;

        private int numeroCuentaI; // número de cuenta del usuario 

        private Pantalla pantalla; // pantalla del ATM 

        private Teclado teclado; //  teclado del ATM 

        private DispensadorEfectivo dispensadorEfectivo; // dispensador de efectivo

        private RanuraDeposito ranuraDeposito; //  la ranura de depósito del ATM 

        private BaseDatos baseDatos;

        private opc OpcMenu {


            Consultar mi Saldo =1,
            Retiro = 2,
            Depostio=3,
            Salir= 4,
        }

        public ATM()
        {
            usuarioAutenticado = false;
            numeroCuentaI = 0;
            pantalla = new Pantalla();
            teclado = new Teclado();
            dispensadorEfectivo = new DispensadorEfectivo();
            ranuraDeposito = new RanuraDeposito();
            baseDatos = new BaseDatos();
        }


        public void Ejecutar() {

            while (true) {

                while (!usuarioAutenticado) {

                    pantalla.MostrarMensaje(" Bienvenido");
                    AutenticarUsuario();

                }
                RealizarTransaccion();
                usuarioAutenticado = false;
                numeroCuentaI = 0;
                pantalla.MostrarMensaje(" Gracias ");
            }
        }

        private void AutenticarUsuario()
        {
            pantalla.MostrarMensaje(" Ingrese su numero de Cuenta :   ");
            int numeroCuenta = teclado.ObtenerEntrada();

            pantalla.MostrarMensaje(" Ingrese su PIN :   ");
            int pin = teclado.ObtenerEntrada();
            baseDatos.AutenticarUsuario(numeroCuenta, pin);

            if (usuarioAutenticado)
                numeroCuentaI = numeroCuenta;
            else
                Console.WriteLine(" Número de Cuenta o PIN INORRECTOS, Ingrese nuevamente  ");
        }

        private void RealizarTransaccion()
        {


            Trans transaccionInicial;
            bool SalidaUsuario = false;

            while (!SalidaUsuario)
            {
                int seleccionMenuP = MostrarMenuP();

                switch ((OpcMenu)seleccionMenuP)
                {

                    case OpcMenu.ConsultarSaldo:
                    case OpcMenu.Retiro:
                    case OpcMenu.Deposito:

                        transaccionInicial = CrearTransaccion(seleccionMenuP);
                        transaccionInicial.Ejecutar();
                        break;

                    case OpcMenu.Salir:
                        Console.WriteLine(" Saliendo del Sistema...");
                        SalidaUsuario = true;
                        break;

                    default:
                        Console.WriteLine("Error !!.. Seleccione de nuevo ");
                        break;
                }
            }
        }

        private int MostrarMenuP()
        {
            Console.WriteLine("\n Menu Principal: ");
            Console.WriteLine("1- Consultar mi saldo  ");
            Console.WriteLine("2- Retirar Efectivo ");
            Console.WriteLine("3- Depsoitar: ");
            Console.WriteLine("4- Salir\n ");
            Console.WriteLine("Introduzca una opción:  ");

            return teclado.ObtenerEntrada();
        }
        private Trans CrearTransaccion(int tipo)
        {
            Trans temp = null; // transaccion nula

            switch ((OpcMenu)tipo)
            {


                case OpcMenu.ConsultarSaldo:
                    temp = new ConsultarSaldo(numeroCuentaI, pantalla, baseDatos);
                    break;


                case OpcMenu.Retiro:
                    temp = new Retiro(numeroCuentaI, pantalla, baseDatos, teclado, dispensadorEfectivo);
                    break;

                case OpcMenu.Deposito:
                    temp = new Depositar(numeroCuentaI, pantalla, baseDatos, teclado, ranuraDeposito);
                    break;
            }
            return temp;
        }
    }

              

            }
        


        















       