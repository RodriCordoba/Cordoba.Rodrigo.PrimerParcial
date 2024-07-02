using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entidades.Indumentaria
{
    [XmlInclude(typeof(Campera))]
    [XmlInclude(typeof(Remera))]
    [XmlInclude(typeof(Pantalon))]
    [JsonConverter(typeof(IndumentariaConvertidor))]
    public abstract class Indumentaria : IIndumentaria<EMaterial>
    {
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public EMaterial TipoMaterial { get; set; }
        public List<Indumentaria> Items { get; set; }

        public Indumentaria()
        {
            Items = new List<Indumentaria>();
        }

        public Indumentaria(string codigo, int cantidad, EMaterial tipoMaterial)
        {
            Codigo = codigo;
            Cantidad = cantidad;
            TipoMaterial = tipoMaterial;
            Items = new List<Indumentaria>();
        }

        public abstract string Descripcion();

        public void SetCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }

        public void SetTipoMaterial(EMaterial tipoMaterial)
        {
            TipoMaterial = tipoMaterial;
        }

        public void SetCodigo(string codigo)
        {
            Codigo = codigo;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Cantidad: {Cantidad}, Material: {TipoMaterial}";
        }

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

            return (Indumentaria)Activator.CreateInstance(a.GetType(), a.Codigo, a.Cantidad + b.Cantidad, a.TipoMaterial);
        }

        public static Indumentaria operator -(Indumentaria a, Indumentaria b)
        {
            if (a.GetType() != b.GetType())
                throw new InvalidOperationException("No se pueden restar prendas de diferente tipo.");

            return (Indumentaria)Activator.CreateInstance(a.GetType(), a.Codigo, a.Cantidad - b.Cantidad, a.TipoMaterial);
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
