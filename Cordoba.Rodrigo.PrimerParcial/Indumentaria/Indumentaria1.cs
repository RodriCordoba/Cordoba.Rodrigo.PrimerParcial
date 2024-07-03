using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase abstracta que representa una prenda de indumentaria.
    /// </summary>
    [XmlInclude(typeof(Campera))]
    [XmlInclude(typeof(Remera))]
    [XmlInclude(typeof(Pantalon))]
    [JsonConverter(typeof(IndumentariaConvertidor))]
    public abstract class Indumentaria : IIndumentaria<EMaterial>
    {
        /// <summary>
        /// Obtiene o establece el código de la prenda.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de la prenda.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de material de la prenda.
        /// </summary>
        public EMaterial TipoMaterial { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de ítems relacionados con la prenda.
        /// </summary>
        public List<Indumentaria> Items { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Indumentaria"/>.
        /// </summary>
        public Indumentaria()
        {
            Items = new List<Indumentaria>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Indumentaria"/> con los parámetros especificados.
        /// </summary>
        /// <param name="codigo">El código de la prenda.</param>
        /// <param name="cantidad">La cantidad de la prenda.</param>
        /// <param name="tipoMaterial">El tipo de material de la prenda.</param>
        public Indumentaria(string codigo, int cantidad, EMaterial tipoMaterial)
        {
            Codigo = codigo;
            Cantidad = cantidad;
            TipoMaterial = tipoMaterial;
            Items = new List<Indumentaria>();
        }

        /// <summary>
        /// Devuelve una descripción de la prenda.
        /// </summary>
        /// <returns>Una cadena que describe la prenda.</returns>
        public abstract string Descripcion();

        /// <summary>
        /// Establece la cantidad de la prenda.
        /// </summary>
        /// <param name="cantidad">La nueva cantidad.</param>
        public void SetCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }

        /// <summary>
        /// Establece el tipo de material de la prenda.
        /// </summary>
        /// <param name="tipoMaterial">El nuevo tipo de material.</param>
        public void SetTipoMaterial(EMaterial tipoMaterial)
        {
            TipoMaterial = tipoMaterial;
        }

        /// <summary>
        /// Establece el código de la prenda.
        /// </summary>
        /// <param name="codigo">El nuevo código.</param>
        public void SetCodigo(string codigo)
        {
            Codigo = codigo;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            return $"Código: {Codigo}, Cantidad: {Cantidad}, Material: {TipoMaterial}";
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>true si el objeto especificado es igual al objeto actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Indumentaria other)
            {
                return Codigo == other.Codigo &&
                       Cantidad == other.Cantidad &&
                       TipoMaterial == other.TipoMaterial;
            }
            return false;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo, Cantidad, TipoMaterial);
        }

        /// <summary>
        /// Sobrecarga del operador == para determinar si dos prendas son iguales.
        /// </summary>
        /// <param name="a">La primera prenda a comparar.</param>
        /// <param name="b">La segunda prenda a comparar.</param>
        /// <returns>true si las prendas son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Indumentaria a, Indumentaria b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        /// <summary>
        /// Sobrecarga del operador != para determinar si dos prendas no son iguales.
        /// </summary>
        /// <param name="a">La primera prenda a comparar.</param>
        /// <param name="b">La segunda prenda a comparar.</param>
        /// <returns>true si las prendas no son iguales; de lo contrario, false.</returns>
        public static bool operator !=(Indumentaria a, Indumentaria b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Sobrecarga del operador + para sumar las cantidades de dos prendas.
        /// </summary>
        /// <param name="a">La primera prenda a sumar.</param>
        /// <param name="b">La segunda prenda a sumar.</param>
        /// <returns>Una nueva instancia de la prenda con la cantidad sumada.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si las prendas son de diferentes tipos.</exception>
        public static Indumentaria operator +(Indumentaria a, Indumentaria b)
        {
            if (a.GetType() != b.GetType())
                throw new InvalidOperationException("No se pueden sumar prendas de diferente tipo.");

            return (Indumentaria)Activator.CreateInstance(a.GetType(), a.Codigo, a.Cantidad + b.Cantidad, a.TipoMaterial);
        }

        /// <summary>
        /// Sobrecarga del operador - para restar las cantidades de dos prendas.
        /// </summary>
        /// <param name="a">La primera prenda a restar.</param>
        /// <param name="b">La segunda prenda a restar.</param>
        /// <returns>Una nueva instancia de la prenda con la cantidad restada.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si las prendas son de diferentes tipos.</exception>
        public static Indumentaria operator -(Indumentaria a, Indumentaria b)
        {
            if (a.GetType() != b.GetType())
                throw new InvalidOperationException("No se pueden restar prendas de diferente tipo.");

            return (Indumentaria)Activator.CreateInstance(a.GetType(), a.Codigo, a.Cantidad - b.Cantidad, a.TipoMaterial);
        }

        /// <summary>
        /// Conversión implícita de <see cref="Indumentaria"/> a <see cref="List{Indumentaria}"/>.
        /// </summary>
        /// <param name="ind">La prenda a convertir.</param>
        public static implicit operator List<Indumentaria>(Indumentaria ind)
        {
            return ind.Items;
        }

        /// <summary>
        /// Conversión explícita de <see cref="Indumentaria"/> a <see cref="string"/>.
        /// </summary>
        /// <param name="ind">La prenda a convertir.</param>
        /// <returns>Una cadena que representa la prenda.</returns>
        public static explicit operator string(Indumentaria ind)
        {
            return ind.ToString();
        }
    }
}
