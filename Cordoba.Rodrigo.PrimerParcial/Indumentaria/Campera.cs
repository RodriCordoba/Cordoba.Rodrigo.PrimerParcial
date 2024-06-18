namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase que representa una campera en el sistema de gestión de indumentaria.
    /// </summary>
    public class Campera : Indumentaria
    {
        public bool TieneCapucha { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Campera.
        /// </summary>
        public Campera() : base() { }

        /// <summary>
        /// Constructor parametrizado de la clase Campera.
        /// </summary>
        /// <param name="codigo">El código de la campera.</param>
        /// <param name="cantidad">La cantidad de unidades disponibles.</param>
        /// <param name="tipoMaterial">El tipo de material de la campera.</param>
        /// <param name="tieneCapucha">Indica si la campera tiene capucha.</param>
        public Campera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneCapucha)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneCapucha = tieneCapucha;
        }

        /// <summary>
        /// Obtiene la descripción de la campera.
        /// </summary>
        /// <returns>La descripción de la campera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Campera, {base.ToString()}, Capucha: {(TieneCapucha ? "Sí" : "No")}";
        }

        /// <summary>
        /// Devuelve la descripción de la campera.
        /// </summary>
        /// <returns>La descripción de la campera.</returns>
        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
