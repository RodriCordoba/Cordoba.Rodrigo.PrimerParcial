using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase genérica que representa un inventario de prendas de indumentaria.
    /// </summary>
    /// <typeparam name="T">El tipo de prenda que se almacena en el inventario. Debe ser una subclase de <see cref="Indumentaria"/>.</typeparam>
    public class Inventario<T> where T : Indumentaria
    {
        private List<T> prendas;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Inventario{T}"/>.
        /// </summary>
        public Inventario()
        {
            this.prendas = new List<T>();
        }

        /// <summary>
        /// Excepción base para errores relacionados con la indumentaria.
        /// </summary>
        public class IndumentariaException : Exception
        {
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="IndumentariaException"/> con un mensaje de error especificado.
            /// </summary>
            /// <param name="message">El mensaje que describe el error.</param>
            public IndumentariaException(string message) : base(message) { }
        }

        /// <summary>
        /// Excepción que se lanza cuando se intenta agregar una prenda con un código duplicado.
        /// </summary>
        public class CodigoDuplicadoException : IndumentariaException
        {
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="CodigoDuplicadoException"/> con un mensaje de error especificado.
            /// </summary>
            /// <param name="message">El mensaje que describe el error.</param>
            public CodigoDuplicadoException(string message) : base(message) { }
        }

        /// <summary>
        /// Excepción que se lanza cuando no se encuentra una prenda en el inventario.
        /// </summary>
        public class PrendaNoEncontradaException : IndumentariaException
        {
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="PrendaNoEncontradaException"/> con un mensaje de error especificado.
            /// </summary>
            /// <param name="message">El mensaje que describe el error.</param>
            public PrendaNoEncontradaException(string message) : base(message) { }
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar una prenda al inventario.
        /// </summary>
        /// <param name="inventario">El inventario al que se agregará la prenda.</param>
        /// <param name="prenda">La prenda que se agregará al inventario.</param>
        /// <returns>El inventario con la prenda agregada.</returns>
        /// <exception cref="CodigoDuplicadoException">Se lanza si la prenda ya existe en el inventario.</exception>
        public static Inventario<T> operator +(Inventario<T> inventario, T prenda)
        {
            if (inventario.prendas.Contains(prenda))
            {
                throw new CodigoDuplicadoException($"La prenda con código {prenda.Codigo} ya existe en el inventario.");
            }
            inventario.prendas.Add(prenda);
            return inventario;
        }

        /// <summary>
        /// Sobrecarga del operador - para eliminar una prenda del inventario.
        /// </summary>
        /// <param name="inventario">El inventario del que se eliminará la prenda.</param>
        /// <param name="prenda">La prenda que se eliminará del inventario.</param>
        /// <returns>El inventario sin la prenda eliminada.</returns>
        /// <exception cref="PrendaNoEncontradaException">Se lanza si la prenda no se encuentra en el inventario.</exception>
        public static Inventario<T> operator -(Inventario<T> inventario, T prenda)
        {
            if (!inventario.prendas.Contains(prenda))
            {
                throw new PrendaNoEncontradaException($"La prenda con código {prenda.Codigo} no se encontró en el inventario.");
            }
            inventario.prendas.Remove(prenda);
            return inventario;
        }

        /// <summary>
        /// Sobrecarga del operador == para determinar si una prenda está en el inventario.
        /// </summary>
        /// <param name="inventario">El inventario a revisar.</param>
        /// <param name="prenda">La prenda a buscar en el inventario.</param>
        /// <returns>true si la prenda está en el inventario; de lo contrario, false.</returns>
        public static bool operator ==(Inventario<T> inventario, T prenda)
        {
            return inventario.prendas.Contains(prenda);
        }

        /// <summary>
        /// Sobrecarga del operador != para determinar si una prenda no está en el inventario.
        /// </summary>
        /// <param name="inventario">El inventario a revisar.</param>
        /// <param name="prenda">La prenda a buscar en el inventario.</param>
        /// <returns>true si la prenda no está en el inventario; de lo contrario, false.</returns>
        public static bool operator !=(Inventario<T> inventario, T prenda)
        {
            return !(inventario == prenda);
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>true si el objeto especificado es igual al objeto actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Inventario<T> other)
            {
                return this.prendas.SequenceEqual(other.prendas);
            }
            return false;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(prendas);
        }

        /// <summary>
        /// Ordena las prendas del inventario por cantidad.
        /// </summary>
        /// <param name="ascendente">true para ordenar en orden ascendente; false para ordenar en orden descendente.</param>
        public void OrdenarPorCantidad(bool ascendente = true)
        {
            if (ascendente)
                prendas = prendas.OrderBy(p => p.Cantidad).ToList();
            else
                prendas = prendas.OrderByDescending(p => p.Cantidad).ToList();
        }

        /// <summary>
        /// Ordena las prendas del inventario por código.
        /// </summary>
        /// <param name="ascendente">true para ordenar en orden ascendente; false para ordenar en orden descendente.</param>
        public void OrdenarPorCodigo(bool ascendente = true)
        {
            if (ascendente)
                prendas = prendas.OrderBy(p => p.Codigo).ToList();
            else
                prendas = prendas.OrderByDescending(p => p.Codigo).ToList();
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T prenda in prendas)
            {
                sb.AppendLine(prenda.ToString());
            }
            return sb.ToString();
        }
    }
}
