using System.Text;

namespace Entidades.Indumentaria
{
    public class Remera : Indumentaria
    {
        public Remera(string codigo, int cantidad, EMaterial tipoMaterial)
            : base(codigo, cantidad, tipoMaterial) { }

        public override string Descripcion()
        {
            return $"Tipo: Remera, {base.ToString()}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
