namespace Entidades.Indumentaria
{
    /// <summary>
    /// Representa un pantalón, que es un tipo de indumentaria.
    /// </summary>
    public class Pantalon : Indumentaria, IIndumentaria<EMaterial>
    {
        /// <summary>
        /// Obtiene o establece un valor que indica si el pantalón es una bermuda.
        /// </summary>
        public bool EsBermuda { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pantalon"/>.
        /// </summary>
        public Pantalon() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pantalon"/> con los valores especificados.
        /// </summary>
        /// <param name="codigo">El código del pantalón.</param>
        /// <param name="cantidad">La cantidad de pantalones.</param>
        /// <param name="tipoMaterial">El tipo de material del pantalón.</param>
        /// <param name="esBermuda">Un valor que indica si el pantalón es una bermuda.</param>
        public Pantalon(string codigo, int cantidad, EMaterial tipoMaterial, bool esBermuda)
            : base(codigo, cantidad, tipoMaterial)
        {
            EsBermuda = esBermuda;
        }

        /// <summary>
        /// Devuelve una descripción del pantalón.
        /// </summary>
        /// <returns>Una cadena que describe el pantalón.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Pantalón, {base.ToString()}, Bermuda: {(EsBermuda ? "Sí" : "No")}";
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            return this.Descripcion();
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>true si el objeto especificado es igual al objeto actual; de lo contrario, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Pantalon other)
            {
                return base.Equals(other) &&
                       EsBermuda == other.EsBermuda;
            }
            return false;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EsBermuda);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Pantalon"/> especificados son iguales.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Pantalon"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Pantalon"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Pantalon"/> son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Pantalon a, Pantalon b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Pantalon"/> especificados son diferentes.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Pantalon"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Pantalon"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Pantalon"/> son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(Pantalon a, Pantalon b)
        {
            return !(a == b);
        }
    }
}
