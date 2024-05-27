using System.Text;

namespace Entidades.Indumentaria
{
    public class Remera : Indumentaria
    {
        public bool EsMangaLarga { get; set; }

        public Remera(int cantidad, EMaterial tipoMaterial, bool esMangaLarga)
            : base(cantidad, tipoMaterial)
        {
            this.EsMangaLarga = esMangaLarga;
        }

        public Remera(int cantidad, EMaterial tipoMaterial)
            : this(cantidad, tipoMaterial, false) { }

        public Remera(int cantidad)
            : this(cantidad, EMaterial.Algodon) { }

        public override string Descripcion()
        {
            return $"{base.ToString()}, Es Manga Larga: {this.EsMangaLarga}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
