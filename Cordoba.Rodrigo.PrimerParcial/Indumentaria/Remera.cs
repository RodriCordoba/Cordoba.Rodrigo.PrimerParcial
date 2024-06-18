using System.Text.Json.Serialization;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Representa una remera en el sistema de gestión de indumentaria.
    /// </summary>
    public class Remera : Indumentaria
    {
        public bool TieneEstampado { get; set; }

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
        /// <param name="tieneEstampado">Indica si la remera tiene estampado.</param>
        public Remera(string codigo, int cantidad, EMaterial tipoMaterial, bool tieneEstampado)
            : base(codigo, cantidad, tipoMaterial)
        {
            TieneEstampado = tieneEstampado;
        }

        /// <summary>
        /// Obtiene la descripción de la remera.
        /// </summary>
        /// <returns>La descripción de la remera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Remera, {base.ToString()}, Estampado: {(TieneEstampado ? "Sí" : "No")}";
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
