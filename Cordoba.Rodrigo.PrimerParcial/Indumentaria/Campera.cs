namespace Entidades.Indumentaria
{
    /// <summary>
    /// Representa una campera, que es un tipo de indumentaria.
    /// </summary>
    public class Campera : Indumentaria, IIndumentaria<EMaterial>
    {
        /// <summary>
        /// Obtiene o establece un valor que indica si la campera tiene capucha.
        /// </summary>
        public bool TieneCapucha { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Campera"/>.
        /// </summary>
        public Campera() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Campera"/> con los valores especificados.
        /// </summary>
        /// <param name="codigo">El código de la campera.</param>
        /// <param name="cantidad">La cantidad de camperas.</param>
        /// <param name="tipoMaterial">El tipo de material de la campera.</param>
        /// <param name="tieneCapucha">Un valor que indica si la campera tiene capucha.</param>
        public Campera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneCapucha)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneCapucha = tieneCapucha;
        }

        /// <summary>
        /// Devuelve una descripción de la campera.
        /// </summary>
        /// <returns>Una cadena que describe la campera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Campera, {base.ToString()}, Capucha: {(TieneCapucha ? "Sí" : "No")}";
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
            if (obj is Campera other)
            {
                return base.Equals(other) &&
                       TieneCapucha == other.TieneCapucha;
            }
            return false;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TieneCapucha);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Campera"/> especificados son iguales.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Campera"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Campera"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Campera"/> son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Campera a, Campera b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Campera"/> especificados son diferentes.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Campera"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Campera"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Campera"/> son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(Campera a, Campera b)
        {
            return !(a == b);
        }
    }
}
