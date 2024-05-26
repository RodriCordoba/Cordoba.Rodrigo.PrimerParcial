using System;
using System.Text;

public abstract class Indumentaria1
{
    protected int cantidad;
    protected EMaterial tipoMaterial;
    protected List<Indumentaria1> items;

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

    public Indumentaria1(int cantidad, EMaterial tipoMaterial)
    {
        this.cantidad = cantidad;
        this.tipoMaterial = tipoMaterial;
        this.items = new List<Indumentaria1>();
    }

    public Indumentaria1(int cantidad) : this(cantidad, EMaterial.Algodon) { }

    public override string ToString()
    {
        return $"Material: {this.tipoMaterial}, Cantidad: {this.cantidad}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Indumentaria1 other)
        {
            return this.tipoMaterial == other.tipoMaterial && this.cantidad == other.cantidad;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(tipoMaterial, cantidad);
    }

    public static bool operator ==(Indumentaria1 a, Indumentaria1 b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Indumentaria1 a, Indumentaria1 b)
    {
        return !(a == b);
    }

    public static Indumentaria1 operator +(Indumentaria1 ind, Indumentaria1 item)
    {
        if (ind != item)
        {
            ind.items.Add(item);
        }
        return ind;
    }

    public static Indumentaria1 operator -(Indumentaria1 ind, Indumentaria1 item)
    {
        if (ind == item)
        {
            ind.items.Remove(item);
        }
        return ind;
    }

    public static implicit operator List<Indumentaria1>(Indumentaria1 ind)
    {
        return ind.items;
    }

    public static explicit operator string(Indumentaria1 ind)
    {
        return ind.ToString();
    }
}
}
