namespace Entities
{
    public class Breadcrump
    {
        public string Nombre { get; set; }
        public string Link { get; set; }

        public Breadcrump(string Nombre, string Link)
        {
            this.Nombre = Nombre;
            this.Link = Link;
        }

        public Breadcrump(string Nombre)
        {
            this.Nombre = Nombre;
        }
        public Breadcrump()
        {
        }

    }
}