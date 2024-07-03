using Entidades.Indumentaria;
using Xunit;

public class IndumentariaTests
{
    [Fact]
    public void Indumentaria_Equals_DevuelveTrueParaObjetosIguales()
    {
        var ind1 = new Campera("001", 10, EMaterial.Algodon, true);
        var ind2 = new Campera("001", 10, EMaterial.Lana, false);

        bool result = ind1.Equals(ind2);

        Assert.True(result);
    }

    [Fact]
    public void Indumentaria_Equals_DevuelveFalseParaObjetosDiferentes()
    {
        var ind1 = new Campera("001", 10, EMaterial.Algodon, true);
        var ind2 = new Campera("002", 5, EMaterial.Lana, false);

        bool result = ind1.Equals(ind2);

        Assert.False(result);
    }

    [Fact]
    public void Indumentaria_OperadorMas_SumaCantidades()
    {
        var ind1 = new Campera("001", 10, EMaterial.Algodon, true);
        var ind2 = new Campera("001", 5, EMaterial.Lana, false);

        var result = ind1 + ind2;

        Assert.Equal(15, result.Cantidad);
    }

    [Fact]
    public void Indumentaria_OperadorMenos_RestaCantidades()
    {
        var ind1 = new Campera("001", 10, EMaterial.Algodon, true);
        var ind2 = new Campera("001", 5, EMaterial.Lana, false);

        var result = ind1 - ind2;

        Assert.Equal(5, result.Cantidad);
    }

    [Fact]
    public void Indumentaria_ToString_DevuelveCadenaCorrecta()
    {
        var ind = new Campera("001", 10, EMaterial.Algodon, true);

        var result = ind.ToString();

        Assert.Equal("Código: 001, Cantidad: 10, Material: Algodon", result);
    }
}
