using System.Text;

namespace Entidades.Indumentaria
{
    public class Campera : Indumentaria
    {
        public Campera(string codigo, int cantidad, EMaterial tipoMaterial)
            : base(codigo, cantidad, tipoMaterial) { }

        public override string Descripcion()
        {
            return $"Tipo: Campera, {base.ToString()}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
