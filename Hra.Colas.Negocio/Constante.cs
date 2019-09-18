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
            // sincronizado con la base de datos
            public const string Administrador = "SA";
            public const string Admision = "AD";
            public const string Medico = "ME";
        }
        public static class Menu {
            public static List<string> Listar(string rol)
            {
                var mnuAdministrador = new List<string> { "Usuario", "Bloque", "Servicio", "Ventanilla" };
                var mnuMedico = new List<string> { "Llamado" };
                var mnuAdmision = new List<string> { "Admision"};
                switch (rol)
                {
                    case Rol.Administrador: return mnuAdministrador;
                    case Rol.Admision: return mnuAdmision;
                    case Rol.Medico: return mnuMedico;
                    default: return null;
                }
            }
        }
        
    }
}
