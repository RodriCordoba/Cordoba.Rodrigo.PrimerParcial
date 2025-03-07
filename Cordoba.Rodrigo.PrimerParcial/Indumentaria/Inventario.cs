﻿using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Clase que representa un inventario de prendas de indumentaria.
/// </summary>
public class Inventario
{
    private List<Indumentaria> prendas;
    /// <summary>
    /// Constructor por defecto de la clase Inventario.
    /// </summary>
    public Inventario()
    {
        this.prendas = new List<Indumentaria>();
    }
    /// <summary>
    /// Sobrecarga del operador '+' para agregar una prenda al inventario.
    /// </summary>
    /// <param name="inventario">El inventario al que se agrega la prenda.</param>
    /// <param name="prenda">La prenda que se agrega al inventario.</param>
    /// <returns>El inventario actualizado.</returns>
    public static Inventario operator +(Inventario inventario, Indumentaria prenda)
    {
        if (!(inventario.prendas.Contains(prenda)))
        {
            inventario.prendas.Add(prenda);
        }
        return inventario;
    }
    /// <summary>
    /// Sobrecarga del operador '-' para quitar una prenda del inventario.
    /// </summary>
    /// <param name="inventario">El inventario del que se quita la prenda.</param>
    /// <param name="prenda">La prenda que se quita del inventario.</param>
    /// <returns>El inventario actualizado.</returns>
    public static Inventario operator -(Inventario inventario, Indumentaria prenda)
    {
        if (inventario.prendas.Contains(prenda))
        {
            inventario.prendas.Remove(prenda);
        }
        return inventario;
    }

    public static bool operator ==(Inventario inventario, Indumentaria prenda)
    {
        return inventario.prendas.Contains(prenda);
    }

    public static bool operator !=(Inventario inventario, Indumentaria prenda)
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

    public List<Indumentaria> GetPrendas()
    {
        return prendas;
    }
}
