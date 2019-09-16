using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra.Colas.Negocio
{
    public class Constante
    {
        public static class Rol
        {
            public const string Administrador = "SA";
            public const string Admision = "AD";
            public const string Medico = "MD";
            
            public static string Obtener(string codigo)
            {
                switch (codigo)
                {
                    case Administrador: return "Pendiente";
                    case Admision: return "Terminado";
                    case Medico: return "Anulado";
                    default: return string.Empty;
                }
            }
        }
    }
}
