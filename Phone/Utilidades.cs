using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    public class Utilidades
    {
        public static int ToInt(string texto)
        {
            int numero;
            int.TryParse(texto, out numero);
            return numero;
        }
    }
}
