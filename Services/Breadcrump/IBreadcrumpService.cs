using Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IBreadcrumpService
    {
        List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1);
        List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2);
        List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2, Breadcrump nivel3);
        List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2, Breadcrump nivel3, Breadcrump nivel4);
    }
}
