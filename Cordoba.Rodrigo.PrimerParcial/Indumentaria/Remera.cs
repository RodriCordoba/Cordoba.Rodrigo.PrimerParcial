using System.Text.Json.Serialization;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Representa una remera, que es un tipo de indumentaria.
    /// </summary>
    public class Remera : Indumentaria, IIndumentaria<EMaterial>
    {
        /// <summary>
        /// Obtiene o establece un valor que indica si la remera tiene estampado.
        /// </summary>
        public bool TieneEstampado { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Remera"/>.
        /// </summary>
        public Remera() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Remera"/> con los valores especificados.
        /// </summary>
        /// <param name="codigo">El código de la remera.</param>
        /// <param name="cantidad">La cantidad de remeras.</param>
        /// <param name="tipoMaterial">El tipo de material de la remera.</param>
        /// <param name="tieneEstampado">Un valor que indica si la remera tiene estampado.</param>
        public Remera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneEstampado)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneEstampado = tieneEstampado;
        }

        /// <summary>
        /// Devuelve una descripción de la remera.
        /// </summary>
        /// <returns>Una cadena que describe la remera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Remera, {base.ToString()}, Estampado: {(TieneEstampado ? "Sí" : "No")}";
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
            if (obj is Remera other)
            {
                return base.Equals(other) &&
                       TieneEstampado == other.TieneEstampado;
            }
            return false;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TieneEstampado);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Remera"/> especificados son iguales.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Remera"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Remera"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Remera"/> son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Remera a, Remera b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determina si dos objetos <see cref="Remera"/> especificados son diferentes.
        /// </summary>
        /// <param name="a">El primer objeto <see cref="Remera"/> a comparar.</param>
        /// <param name="b">El segundo objeto <see cref="Remera"/> a comparar.</param>
        /// <returns>true si los objetos <see cref="Remera"/> son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(Remera a, Remera b)
        {
            return !(a == b);
        }
    }
}
