using System.Text;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Representa una remera en el sistema de gestión de indumentaria.
    /// </summary>
    public class Remera : Indumentaria
    {
        /// <summary>
        /// Constructor por defecto de la clase Remera.
        /// </summary>
        public Remera() : base() { }
        /// <summary>
        /// Constructor parametrizado de la clase Remera.
        /// </summary>
        /// <param name="codigo">El código de la remera.</param>
        /// <param name="cantidad">La cantidad de unidades disponibles.</param>
        /// <param name="tipoMaterial">El tipo de material de la remera.</param>
        public Remera(string codigo, int cantidad, EMaterial tipoMaterial)
            : base(codigo, cantidad, tipoMaterial) { }
        /// <summary>
        /// Obtiene la descripción de la remera.
        /// </summary>
        /// <returns>La descripción de la remera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Remera, {base.ToString()}";
        }
        /// <summary>
        /// Devuelve la descripción de la remera.
        /// </summary>
        /// <returns>La descripción de la remera.</returns>
        public override string ToString()
        {
            return this.Descripcion();
        }
    }
}
