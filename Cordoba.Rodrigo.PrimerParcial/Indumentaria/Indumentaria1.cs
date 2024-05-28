using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Indumentaria
{
    public abstract class Indumentaria
    {
        protected string codigo;
        protected int cantidad;
        protected EMaterial tipoMaterial;
        protected List<Indumentaria> items;

        public int Cantidad
        {
            get { return cantidad; }
        }

        public EMaterial TipoMaterial
        {
            get { return tipoMaterial; }
        }

        public string Codigo
        {
            get { return codigo; }
        }

        public abstract string Descripcion();

        public Indumentaria(string codigo, int cantidad, EMaterial tipoMaterial)
        {
            this.codigo = codigo;
            this.cantidad = cantidad;
            this.tipoMaterial = tipoMaterial;
            this.items = new List<Indumentaria>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nCódigo: {this.codigo}");
            sb.AppendLine($"Cantidad: {this.cantidad}");
            sb.AppendLine($"Material: {this.tipoMaterial}");
            return sb.ToString();
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
