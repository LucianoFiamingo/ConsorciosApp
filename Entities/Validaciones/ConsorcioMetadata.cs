using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class ConsorcioMetadata
    {
        [Required (ErrorMessage ="Nombre es requerido")]
        [MaxLength (20,ErrorMessage ="El numero maximo de caracteres es veinte") ]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ciudad es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Calle es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "Altura es requerido")]
        [Range(1,30000,ErrorMessage ="Altura invalida")]
        public int Altura { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha del vencimiento es requerida")]
        public int DiaVencimientoExpensas { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha de creacion es requerida")]
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