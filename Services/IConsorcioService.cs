using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios
{
    public interface IConsorcioService
    {
        List<Consorcio> GetAll();
    }
}
