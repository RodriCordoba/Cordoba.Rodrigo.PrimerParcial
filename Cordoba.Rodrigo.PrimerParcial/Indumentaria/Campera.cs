﻿using System.Text;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase que representa una campera en el sistema de gestión de indumentaria.
    /// </summary>
    public class Campera : Indumentaria
    {
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
        public Campera(string codigo, int cantidad, EMaterial tipoMaterial)
            : base(codigo, cantidad, tipoMaterial) { }
        /// <summary>
        /// Obtiene la descripción de la campera.
        /// </summary>
        /// <returns>La descripción de la campera.</returns>
        public override string Descripcion()
        {
            return $"Tipo: Campera, {base.ToString()}";
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
