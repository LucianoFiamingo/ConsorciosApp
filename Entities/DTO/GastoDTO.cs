using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class GastoDTO
    {

        [Display(Name = "Año")]
        public int Anio { get; set; }

        public int Mes { get; set; }

        [Display (Name = "Gasto Total")]
        public int GastoTotal { get; set; }

        [Display(Name = "Expensa por Unidad")]
        public int ExpensaPorUnidad { get; set; }

    }
}