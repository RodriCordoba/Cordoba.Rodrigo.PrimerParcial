using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Indumentaria
{
    public abstract class Indumentaria
    {
        protected int cantidad;
        protected EMaterial tipoMaterial;
        protected List<Indumentaria> items;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public EMaterial TipoMaterial
        {
            get { return tipoMaterial; }
            set { tipoMaterial = value; }
        }

        public abstract string Descripcion();

        public Indumentaria(int cantidad, EMaterial tipoMaterial)
        {
            this.cantidad = cantidad;
            this.tipoMaterial = tipoMaterial;
            this.items = new List<Indumentaria>();
        }

        public Indumentaria(int cantidad) : this(cantidad, EMaterial.Algodon) { }

        public override string ToString()
        {
            return $"Material: {this.tipoMaterial}, Cantidad: {this.cantidad}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Indumentaria other)
            {
                return this.tipoMaterial == other.tipoMaterial && this.cantidad == other.cantidad;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(tipoMaterial, cantidad);
        }

        public static bool operator ==(Indumentaria a, Indumentaria b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Indumentaria a, Indumentaria b)
        {
            return !(a == b);
        }

        public static Indumentaria operator +(Indumentaria ind, Indumentaria item)
        {
            if (ind != item)
            {
                ind.items.Add(item);
            }
            return ind;
        }

        public static Indumentaria operator -(Indumentaria ind, Indumentaria item)
        {
            if (ind == item)
            {
                ind.items.Remove(item);
            }
            return ind;
        }

        public static implicit operator List<Indumentaria>(Indumentaria ind)
        {
            return ind.items;
        }

        public static explicit operator string(Indumentaria ind)
        {
            return ind.ToString();
        }
    }
}
