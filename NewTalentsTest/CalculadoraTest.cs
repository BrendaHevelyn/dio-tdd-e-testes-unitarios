using NewTalents.Services;


namespace NewTalentsTest;

public class UnitTest1
{
    public Calculadora construirClasse()
    {
        string data = "02/02/2020";
        Calculadora calculadora = new Calculadora(data);
        return calculadora;

    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TestSoma(int val1, int val2, int resultado)
    {
        Calculadora calculadora = construirClasse();

        int resultadoCalculadora = calculadora.Somar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (6, 2, 4)]
    [InlineData (5, 5, 0)]
    public void TestSubtrair(int val1, int val2, int resultado)
    {
        Calculadora calculadora = construirClasse();

        int resultadoCalculadora = calculadora.Subtrair(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void TestMultiplicar(int val1, int val2, int resultado)
    {
        Calculadora calculadora = construirClasse();

        int resultadoCalculadora = calculadora.Multiplicar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (5, 5, 1)]
    public void TestDividir(int val1, int val2, int resultado)
    {
        Calculadora calculadora = construirClasse();

        int resultadoCalculadora = calculadora.Dividir(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TesteDivisaoPorZero()
    {
        Calculadora calculadora = construirClasse();

        Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(3, 0));
    }

    [Fact]
    public void TesteHistorico()
    {
        Calculadora calculadora = construirClasse();

        calculadora.Somar(5, 2);
        calculadora.Somar(7, 2);
        calculadora.Somar(9, 2);

        var lista = calculadora.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}