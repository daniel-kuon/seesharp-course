public class FizzBuzzTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(7, "7")]
    [InlineData(98, "98")]
    public void Gewoehnliche_Zahlen_bleiben_Zahlen(int zahl, string erwartet) => Assert.Equal(erwartet, FizzBuzz.Wort(zahl));

    [Theory]
    [InlineData(3)]
    [InlineData(9)]
    [InlineData(99)]
    public void Vielfache_von_3_sind_Fizz(int zahl) => Assert.Equal("Fizz", FizzBuzz.Wort(zahl));

    [Theory]
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(100)]
    public void Vielfache_von_5_sind_Buzz(int zahl) => Assert.Equal("Buzz", FizzBuzz.Wort(zahl));

    [Theory]
    [InlineData(15)]
    [InlineData(45)]
    [InlineData(90)]
    public void Vielfache_von_15_sind_FizzBuzz(int zahl) => Assert.Equal("FizzBuzz", FizzBuzz.Wort(zahl));

    [Fact]
    public void Folge_bis_5() => Assert.Equal("1 2 Fizz 4 Buzz", FizzBuzz.Folge(5));

    [Fact]
    public void Folge_bis_15() =>
        Assert.Equal("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz", FizzBuzz.Folge(15));

    [Fact]
    public void Folge_bis_1() => Assert.Equal("1", FizzBuzz.Folge(1));
}
