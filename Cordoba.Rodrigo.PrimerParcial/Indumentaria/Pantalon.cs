using System.Text;

namespace Entidades.Indumentaria
{
    public class Pantalon : Indumentaria
    {
        public Pantalon(string codigo, int cantidad, EMaterial tipoMaterial)
            : base(codigo, cantidad, tipoMaterial) { }

        public override string Descripcion()
        {
            return $"Tipo: Pantalón, {base.ToString()}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
