using System.Text;

namespace Entidades.Indumentaria
{
    public class Pantalon : Indumentaria1
    {
        public bool EsJean { get; set; }

        public Pantalon(int cantidad, EMaterial tipoMaterial, bool esJean)
            : base(cantidad, tipoMaterial)
        {
            this.EsJean = esJean;
        }

        public Pantalon(int cantidad, EMaterial tipoMaterial)
            : this(cantidad, tipoMaterial, false) { }

        public Pantalon(int cantidad)
            : this(cantidad, EMaterial.Algodon) { }

        public override string Descripcion()
        {
            return $"{base.ToString()}, Es Jean: {this.EsJean}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
