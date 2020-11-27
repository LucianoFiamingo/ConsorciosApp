using Entities;
using Entities.DTO;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IExpensasService
    {
        ExpensaDTO ObtenerDatosExpensaPorConsorcio(int id);

    }
}
