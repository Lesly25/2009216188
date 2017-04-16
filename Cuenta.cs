using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009216188
{
    public class Cuenta
    {
        private int numeroCuenta;
        private int pin;
        private decimal saldoDisponible;
        private decimal saldoTotal;

        public Cuenta(int numeroCuenta1, int pin1, decimal saldoDisponible1, decimal saldoTotal1)
        {
            numeroCuenta = numeroCuenta1;
            pin = pin1;
            saldoDisponible = saldoDisponible1;
            saldoTotal = saldoTotal1;
        }

        public int NumeroCuenta
        {

            get
            {
                return numeroCuenta;
            }
        }

        public decimal saldoDisponible
        {
            get
            {
                return saldoDisponible;

            }
        }

        public bool ValidarPIN(int pinUusuario)
        {
            return (pinUusuario == pin);

        }
        public void Acreditar(decimal monto)
        {

            saldoDisponible1 += monto; // lo suma al saldo total
        }
        public void Debitar(decimal monto)
        {
            saldoDisponible1 -= monto;
            saldoTotal -= monto;
        }


    }
}
         
        


   

