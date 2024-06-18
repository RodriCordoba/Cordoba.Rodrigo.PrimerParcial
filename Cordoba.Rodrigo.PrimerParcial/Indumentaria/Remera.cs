using System.Text.Json.Serialization;

namespace Entidades.Indumentaria
{
    public class Remera : Indumentaria
    {
        public bool TieneEstampado { get; set; }

        public Remera() : base() { }

        public Remera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneEstampado)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneEstampado = tieneEstampado;
        }

        public override string Descripcion()
        {
            return $"Tipo: Remera, {base.ToString()}, Estampado: {(TieneEstampado ? "Sí" : "No")}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }

        public override bool Equals(object obj)
        {
            if (obj is Remera other)
            {
                return base.Equals(other) &&
                       TieneEstampado == other.TieneEstampado;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TieneEstampado);
        }

        public static bool operator ==(Remera a, Remera b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Remera a, Remera b)
        {
            return !(a == b);
        }
    }
}
