using System.Reflection;

public class FamilieTests
{
    [Fact]
    public void Informiere_nennt_Familie_Tochter_und_Sohn()
    {
        var f = new Familie("Müller", "Lea", 7, "Theo", 4);

        var text = f.Informiere();

        Assert.Equal(
            "Die Kinder von Familie Müller:\n" +
            "Ich bin die 7-jährige Tochter Lea von Familie Müller.\n" +
            "Ich bin der 4-jährige Sohn Theo von Familie Müller.",
            text);
    }

    [Fact]
    public void Sohn_ist_oeffentlich_geschachtelt_und_liest_den_privaten_Familiennamen()
    {
        var f = new Familie("Schmidt", "Ida", 9, "Max", 2);

        var sohn = new Familie.Sohn(f, "Paul", 1);

        Assert.Equal("Ich bin der 1-jährige Sohn Paul von Familie Schmidt.", sohn.Informiere());
    }

    [Fact]
    public void Tochter_ist_eine_private_geschachtelte_Klasse()
    {
        var tochter = typeof(Familie).GetNestedType("Tochter", BindingFlags.NonPublic);

        Assert.NotNull(tochter);
        Assert.True(tochter!.IsNestedPrivate);
    }
}
