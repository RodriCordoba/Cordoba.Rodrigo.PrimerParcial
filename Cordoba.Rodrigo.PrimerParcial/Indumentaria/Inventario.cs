using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Indumentaria
{
    public class Inventario<T> where T : IIndumentaria<EMaterial>
    {
        private List<T> prendas;

        public Inventario()
        {
            this.prendas = new List<T>();
        }

        public static Inventario<T> operator +(Inventario<T> inventario, T prenda)
        {
            if (!inventario.prendas.Contains(prenda))
            {
                inventario.prendas.Add(prenda);
            }
            return inventario;
        }

        public static Inventario<T> operator -(Inventario<T> inventario, T prenda)
        {
            if (inventario.prendas.Contains(prenda))
            {
                inventario.prendas.Remove(prenda);
            }
            return inventario;
        }

        public static bool operator ==(Inventario<T> inventario, T prenda)
        {
            return inventario.prendas.Contains(prenda);
        }

        public static bool operator !=(Inventario<T> inventario, T prenda)
        {
            return !(inventario == prenda);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Inventario<T> other)
            {
                return this.prendas.SequenceEqual(other.prendas);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(prendas);
        }

        public void OrdenarPorCantidad(bool ascendente = true)
        {
            if (ascendente)
                prendas = prendas.OrderBy(p => p.Cantidad).ToList();
            else
                prendas = prendas.OrderByDescending(p => p.Cantidad).ToList();
        }

        public void OrdenarPorCodigo(bool ascendente = true)
        {
            if (ascendente)
                prendas = prendas.OrderBy(p => p.Codigo).ToList();
            else    
                prendas = prendas.OrderByDescending(p => p.Codigo).ToList();
        }

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
