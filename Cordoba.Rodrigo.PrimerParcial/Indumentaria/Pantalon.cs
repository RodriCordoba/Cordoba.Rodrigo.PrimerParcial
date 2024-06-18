namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase que representa un pantalón en el sistema de gestión de indumentaria.
    /// </summary>
    public class Pantalon : Indumentaria
    {
        public bool EsBermuda { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase Pantalon.
        /// </summary>
        public Pantalon() : base() { }

        /// <summary>
        /// Constructor parametrizado de la clase Pantalon.
        /// </summary>
        /// <param name="codigo">El código del pantalón.</param>
        /// <param name="cantidad">La cantidad de unidades disponibles.</param>
        /// <param name="tipoMaterial">El tipo de material del pantalón.</param>
        /// <param name="esBermuda">Indica si el pantalón es una bermuda.</param>
        public Pantalon(string codigo, int cantidad, EMaterial tipoMaterial, bool esBermuda)
            : base(codigo, cantidad, tipoMaterial)
        {
            EsBermuda = esBermuda;
        }

        /// <summary>
        /// Obtiene la descripción del pantalón.
        /// </summary>
        /// <returns>La descripción del pantalón.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Pantalón, {base.ToString()}, Bermuda: {(EsBermuda ? "Sí" : "No")}";
        }

        /// <summary>
        /// Devuelve la descripción del pantalón.
        /// </summary>
        /// <returns>La descripción del pantalón.</returns>
        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
