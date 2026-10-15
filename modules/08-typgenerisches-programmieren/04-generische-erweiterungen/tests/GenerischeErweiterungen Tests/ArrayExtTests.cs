public class ArrayExtTests
{
    [Fact]
    public void MinFirst_prueft_ob_das_Minimum_vorn_steht()
    {
        Assert.False(new[] { 3, 1, 4, 1, 5 }.MinFirst);
        Assert.True(new[] { "abc", "def" }.MinFirst);
        Assert.True(new[] { 2, 2, 3 }.MinFirst);
        Assert.Null(Array.Empty<int>().MinFirst);
    }

    [Fact]
    public void LeadingMin_verhaelt_sich_wie_MinFirst()
    {
        Assert.False(new[] { 3, 1 }.LeadingMin());
        Assert.True(new[] { 1.5, 2.5 }.LeadingMin());
        Assert.Null(Array.Empty<string>().LeadingMin());
    }

    [Fact]
    public void Groesstes_findet_das_Maximum()
    {
        Assert.Equal(5, new[] { 3, 1, 4, 1, 5 }.Groesstes());
        Assert.Equal("def", new[] { "abc", "def", "abd" }.Groesstes());
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().Groesstes());
    }

    [Fact]
    public void Umgekehrt_liefert_ein_neues_Array()
    {
        int[] original = [1, 2, 3];

        var r = original.Umgekehrt();

        Assert.Equal([3, 2, 1], r);
        Assert.Equal([1, 2, 3], original);
        Assert.Equal(["b", "a"], new[] { "a", "b" }.Umgekehrt());
    }
}
