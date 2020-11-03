using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IConsorcioService
    {
        Consorcio ObtenerConsorcioCompleto(long? IdConsorcio);

    }
}
