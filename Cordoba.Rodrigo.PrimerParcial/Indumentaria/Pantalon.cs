namespace Entidades.Indumentaria
{
    public class Pantalon : Indumentaria
    {
        public bool EsBermuda { get; set; }

        public Pantalon() : base() { }

        public Pantalon(string codigo, int cantidad, EMaterial tipoMaterial, bool esBermuda)
            : base(codigo, cantidad, tipoMaterial)
        {
            EsBermuda = esBermuda;
        }

        public override string Descripcion()
        {
            return $"Tipo: Pantalón, {base.ToString()}, Bermuda: {(EsBermuda ? "Sí" : "No")}";
        }

        public override string ToString()
        {
            return this.Descripcion();
        }

        public override bool Equals(object obj)
        {
            if (obj is Pantalon other)
            {
                return base.Equals(other) &&
                       EsBermuda == other.EsBermuda;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EsBermuda);
        }

        public static bool operator ==(Pantalon a, Pantalon b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Pantalon a, Pantalon b)
        {
            return !(a == b);
        }
    }
}
