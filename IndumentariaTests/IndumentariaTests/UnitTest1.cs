using Entidades.Indumentaria;
using Xunit;

public class IndumentariaTests
{
    [Fact]
    public void Indumentaria_Equals_TrueForEqualObjects()
    {
        var ind1 = new Campera("001", 10, EMaterial.Cuero);
        var ind2 = new Campera("001", 10, EMaterial.Cuero);

        bool result = ind1.Equals(ind2);

        Assert.True(result);
    }

    [Fact]
    public void Indumentaria_Equals_FalseForDifferentObjects()
    {
        var ind1 = new Campera("001", 10, EMaterial.Cuero);
        var ind2 = new Campera("002", 5, EMaterial.Algodon);

        bool result = ind1.Equals(ind2);

        Assert.False(result);
    }

    [Fact]
    public void Indumentaria_OperatorPlus_AddsQuantities()
    {
        var ind1 = new Campera("001", 10, EMaterial.Cuero);
        var ind2 = new Campera("001", 5, EMaterial.Cuero);

        var result = ind1 + ind2;

        Assert.Equal(15, result.Cantidad);
    }

    [Fact]
    public void Indumentaria_OperatorMinus_SubtractsQuantities()
    {
        var ind1 = new Campera("001", 10, EMaterial.Cuero);
        var ind2 = new Campera("001", 5, EMaterial.Cuero);

        var result = ind1 - ind2;

        Assert.Equal(5, result.Cantidad);
    }

    [Fact]
    public void Indumentaria_ToString_ReturnsCorrectString()
    {
        var ind = new Campera("001", 10, EMaterial.Cuero);

        var result = ind.ToString();

        Assert.Equal("Código: 001, Cantidad: 10, Material: Cuero", result);
    }
}
