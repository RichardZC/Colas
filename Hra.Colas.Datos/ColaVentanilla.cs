//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hra.Colas.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ColaVentanilla
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int ColaId { get; set; }
        public int VentanillaId { get; set; }
        public bool IndAtendido { get; set; }
    
        public virtual Cola Cola { get; set; }
        public virtual Ventanilla Ventanilla { get; set; }
    }
}
