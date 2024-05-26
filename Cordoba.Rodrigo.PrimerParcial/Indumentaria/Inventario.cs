using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Inventario
{
    private List<Indumentaria1> prendas;

    public Inventario()
    {
        this.prendas = new List<Indumentaria1>();
    }

    public static Inventario operator +(Inventario inventario, Indumentaria1 prenda)
    {
        if (!(inventario.prendas.Contains(prenda)))
        {
            inventario.prendas.Add(prenda);
        }
        return inventario;
    }

    public static Inventario operator -(Inventario inventario, Indumentaria1 prenda)
    {
        if (inventario.prendas.Contains(prenda))
        {
            inventario.prendas.Remove(prenda);
        }
        return inventario;
    }

    public static bool operator ==(Inventario inventario, Indumentaria1 prenda)
    {
        return inventario.prendas.Contains(prenda);
    }

    public static bool operator !=(Inventario inventario, Indumentaria1 prenda)
    {
        return !(inventario == prenda);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Inventario other)
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

    public void OrdenarPorTipoMaterial(bool ascendente = true)
    {
        if (ascendente)
            prendas = prendas.OrderBy(p => p.TipoMaterial).ToList();
        else
            prendas = prendas.OrderByDescending(p => p.TipoMaterial).ToList();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var prenda in prendas)
        {
            sb.AppendLine(prenda.ToString());
        }
        return sb.ToString();
    }

    public List<Indumentaria1> GetPrendas()
    {
        return prendas;
    }
}
