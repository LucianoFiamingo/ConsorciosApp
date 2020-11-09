using System.Collections.Generic;
using Entities;

namespace Services
{
    public class BreadcrumpService : IBreadcrumpService
    {
        public List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1)
        {
            List<Breadcrump> breadcrumps = new List<Breadcrump>();
            breadcrumps.Add(nivel1);
            return breadcrumps;
        }
        public List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2)
        {
            List<Breadcrump> breadcrumps = new List<Breadcrump>();
            breadcrumps.Add(nivel1);
            breadcrumps.Add(nivel2);
            return breadcrumps;
        }
        public List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2, Breadcrump nivel3)
        {
            List<Breadcrump> breadcrumps = new List<Breadcrump>();
            breadcrumps.Add(nivel1);
            breadcrumps.Add(nivel2);
            breadcrumps.Add(nivel3);
            return breadcrumps;
        }
        public List<Breadcrump> SetListaBreadcrumps(Breadcrump nivel1, Breadcrump nivel2, Breadcrump nivel3, Breadcrump nivel4)
        {
            List<Breadcrump> breadcrumps = new List<Breadcrump>();
            breadcrumps.Add(nivel1);
            breadcrumps.Add(nivel2);
            breadcrumps.Add(nivel3);
            breadcrumps.Add(nivel4);
            return breadcrumps;
        }
    }
}
