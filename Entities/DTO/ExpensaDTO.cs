using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class ExpensaDTO
    {
        [Display(Name = "Gastos Por Mes")]
        public List<GastoDTO> GastosMes;

        [Display(Name = "Cantidad de Unidades")]
        public int CantidadUnidades { get; set; }

    }
}