//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaArs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plane()
        {
            this.Afiliados = new HashSet<Afiliado>();
        }
    
        public int Id_Planes { get; set; }
        public string Planes { get; set; }
        public Nullable<int> MCobertura { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public string Estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Afiliado> Afiliados { get; set; }
    }
}
