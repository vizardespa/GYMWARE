//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gymware.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public int IdHorario { get; set; }
        public int IdMembresia { get; set; }
        public int IdCurso { get; set; }
        public string Dia { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Membresia Membresia { get; set; }
    }
}
