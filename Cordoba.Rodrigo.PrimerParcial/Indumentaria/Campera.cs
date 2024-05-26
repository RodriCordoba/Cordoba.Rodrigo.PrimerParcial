using System.Text;

namespace Entidades.Indumentaria
{
    public class Campera : Indumentaria1
    {
        public bool ConCapucha { get; set; }

        public Campera(int cantidad, EMaterial tipoMaterial, bool conCapucha)
            : base(cantidad, tipoMaterial)
        {
            this.ConCapucha = conCapucha;
        }

        public Campera(int cantidad, EMaterial tipoMaterial)
            : this(cantidad, tipoMaterial, false) { }

        public Campera(int cantidad)
            : this(cantidad, EMaterial.Algodon) { }

        public override string Descripcion()
        {
            return $"{base.ToString()}, Con Capucha: {this.ConCapucha}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
