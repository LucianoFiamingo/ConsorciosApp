using System;
using System.Collections.Generic;

namespace Entities.EDMX
{
    internal class ConsorcioMetadata
    {
        public string Nombre { get; set; }
        public int IdProvincia { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int DiaVencimientoExpensas { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreador { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gasto> Gastoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unidad> Unidads { get; set; }
    }
}