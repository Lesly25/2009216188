using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009216188
{
    public class DispensadorEfectivo
    {

        private const int CuentaInic = 500;

        private int cuentaBilletes;



        public DispensadorEfectivo()
        {
            cuentaBilletes = CuentaInic;
        }

             


            public void DispensadorEfectivo(decimal monto)
            {
                int billetes = ((int)monto) / 20;
                cuentaBilletes -= billetes;

            }
            public void SuficienteEfectivo(decimal monto)  {
                int billetes = ((int)monto / 20);
                return (cuentaBilletes >= billetes);
            }
        

    }

    
}