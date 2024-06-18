using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entidades.Indumentaria
{
    /// <summary>
    /// Clase abstracta que representa una prenda de indumentaria en el sistema.
    /// </summary>
    [XmlInclude(typeof(Campera))]
    [XmlInclude(typeof(Remera))]
    [XmlInclude(typeof(Pantalon))]
    [JsonConverter(typeof(IndumentariaConvertidor))]
    public abstract class Indumentaria
    {
        /// <summary>
        /// El código de identificación de la prenda.
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// La cantidad de unidades disponibles de la prenda.
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// El tipo de material de la prenda.
        /// </summary>
        public EMaterial TipoMaterial { get; set; }
        /// <summary>
        /// La lista de ítems que componen esta prenda (si aplica).
        /// </summary>
        public List<Indumentaria> Items { get; set; }
        /// <summary>
        /// Constructor por defecto de la clase Indumentaria.
        /// </summary>
        public Indumentaria()
        {
            Items = new List<Indumentaria>();
        }
        /// <summary>
        /// Constructor parametrizado de la clase Indumentaria.
        /// </summary>
        /// <param name="codigo">El código de identificación de la prenda.</param>
        /// <param name="cantidad">La cantidad de unidades disponibles de la prenda.</param>
        /// <param name="tipoMaterial">El tipo de material de la prenda.</param>
        public Indumentaria(string codigo, int cantidad, EMaterial tipoMaterial)
        {
            Codigo = codigo;
            Cantidad = cantidad;
            TipoMaterial = tipoMaterial;
            Items = new List<Indumentaria>();
        }
        /// <summary>
        /// Obtiene una descripción de la prenda.
        /// </summary>
        /// <returns>Una descripción de la prenda.</returns>
        public abstract string Descripcion();
        /// <summary>
        /// Establece la cantidad de unidades disponibles de la prenda.
        /// </summary>
        /// <param name="cantidad">La cantidad de unidades disponibles.</param>
        public void SetCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }
        /// <summary>
        /// Establece el tipo de material de la prenda.
        /// </summary>
        /// <param name="tipoMaterial">El tipo de material de la prenda.</param>
        public void SetTipoMaterial(EMaterial tipoMaterial)
        {
            TipoMaterial = tipoMaterial;
        }
        /// <summary>
        /// Establece el código de identificación de la prenda.
        /// </summary>
        /// <param name="codigo">El código de identificación de la prenda.</param>
        public void SetCodigo(string codigo)
        {
            Codigo = codigo;
        }
        /// <summary>
        /// Devuelve una representación de cadena de la prenda.
        /// </summary>
        /// <returns>Una representación de cadena de la prenda.</returns>
        public override string ToString()
        {
            return $"Código: {Codigo}, Cantidad: {Cantidad}, Material: {TipoMaterial}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Indumentaria other)
            {
                return Codigo == other.Codigo &&
                       Cantidad == other.Cantidad &&
                       TipoMaterial == other.TipoMaterial;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo, Cantidad, TipoMaterial);
        }

        public static bool operator ==(Indumentaria a, Indumentaria b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Indumentaria a, Indumentaria b)
        {
            return !(a == b);
        }

        public static Indumentaria operator +(Indumentaria a, Indumentaria b)
        {
            if (a.GetType() != b.GetType())
                throw new InvalidOperationException("No se pueden sumar prendas de diferente tipo.");

            return (Indumentaria)Activator.CreateInstance(a.GetType(), b.Codigo, a.Cantidad + b.Cantidad, a.TipoMaterial);
        }

        public static Indumentaria operator -(Indumentaria a, Indumentaria b)
        {
            if (a.GetType() != b.GetType())
                throw new InvalidOperationException("No se pueden restar prendas de diferente tipo.");

            return (Indumentaria)Activator.CreateInstance(a.GetType(), b.Codigo, a.Cantidad - b.Cantidad, a.TipoMaterial);
        }

        public static implicit operator List<Indumentaria>(Indumentaria ind)
        {
            return ind.Items;
        }

        public static explicit operator string(Indumentaria ind)
        {
            return ind.ToString();
        }
    }
}
