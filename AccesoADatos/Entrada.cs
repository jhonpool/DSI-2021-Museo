//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entrada
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> FechaVenta { get; set; }
        public string HoraVenta { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Numero { get; set; }
        public Nullable<int> IdSede { get; set; }
        public Nullable<int> IdTarifa { get; set; }
    
        public virtual Sede Sede { get; set; }
        public virtual Tarifa Tarifa { get; set; }
    }
}
