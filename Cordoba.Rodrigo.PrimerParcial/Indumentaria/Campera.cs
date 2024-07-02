namespace Entidades.Indumentaria
{
    public class Campera : Indumentaria, IIndumentaria<EMaterial>
    {
        public bool TieneCapucha { get; set; }

        public Campera() : base() { }

        public Campera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneCapucha)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneCapucha = tieneCapucha;
        }

        public override string Descripcion()
        {
            return $"Tipo: Campera, {base.ToString()}, Capucha: {(TieneCapucha ? "Sí" : "No")}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }

        public override bool Equals(object obj)
        {
            if (obj is Campera other)
            {
                return base.Equals(other) &&
                       TieneCapucha == other.TieneCapucha;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TieneCapucha);
        }

        public static bool operator ==(Campera a, Campera b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Campera a, Campera b)
        {
            return !(a == b);
        }
    }
}
