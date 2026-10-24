using System.Reflection;

public class EigeneAttributeTests
{
    static AttributeUsageAttribute Verwendung(Type attributTyp)
    {
        var verwendung = attributTyp.GetCustomAttribute<AttributeUsageAttribute>();
        Assert.NotNull(verwendung);
        return verwendung!;
    }

    // Über object gecastet, damit das Projekt auch übersetzt, solange eine Attributklasse noch nicht von Attribute erbt.
    static T? Hole<T>(MemberInfo ziel) where T : class =>
        (T?)(object?)Attribute.GetCustomAttribute(ziel, typeof(T));

    // ---------- AutorAttribute

    [Fact]
    public void Autor_ist_ein_Attribut()
    {
        Assert.True(typeof(Attribute).IsAssignableFrom(typeof(AutorAttribute)));
    }

    [Fact]
    public void Autor_darf_nur_an_Klassen_und_Methoden_stehen()
    {
        var verwendung = Verwendung(typeof(AutorAttribute));

        Assert.Equal(AttributeTargets.Class | AttributeTargets.Method, verwendung.ValidOn);
        // Folge: An einer Eigenschaft wäre [Autor] ein Übersetzungsfehler.
        Assert.False(verwendung.ValidOn.HasFlag(AttributeTargets.Property));
    }

    [Fact]
    public void Autor_darf_mehrfach_am_selben_Ziel_stehen()
    {
        Assert.True(Verwendung(typeof(AutorAttribute)).AllowMultiple);
    }

    [Fact]
    public void Autor_hat_positionalen_Namen_und_benannte_Version_mit_Standard_1()
    {
        var a = new AutorAttribute("Zoe");
        Assert.Equal("Zoe", a.Name);
        Assert.Equal(1, a.Version);

        var b = new AutorAttribute("Max") { Version = 5 };
        Assert.Equal(5, b.Version);
    }

    // ---------- SpalteAttribute

    [Fact]
    public void Spalte_ist_ein_Attribut_nur_fuer_Eigenschaften()
    {
        Assert.True(typeof(Attribute).IsAssignableFrom(typeof(SpalteAttribute)));
        Assert.Equal(AttributeTargets.Property, Verwendung(typeof(SpalteAttribute)).ValidOn);
        Assert.Equal("id", new SpalteAttribute("id").Name);
    }

    // ---------- ImplementierungAttribute<T>

    [Fact]
    public void Implementierung_ist_ein_generisches_Attribut_fuer_Klassen()
    {
        Assert.True(typeof(ImplementierungAttribute<>).IsGenericTypeDefinition);
        Assert.True(typeof(Attribute).IsAssignableFrom(typeof(ImplementierungAttribute<StandardRechnung>)));
        Assert.Equal(AttributeTargets.Class, Verwendung(typeof(ImplementierungAttribute<StandardRechnung>)).ValidOn);
    }

    [Fact]
    public void Implementierung_verlangt_per_Typeinschraenkung_eine_IRechnung()
    {
        Type parameter = typeof(ImplementierungAttribute<>).GetGenericArguments()[0];
        Assert.Contains(typeof(IRechnung), parameter.GetGenericParameterConstraints());
    }

    [Fact]
    public void Implementierung_liefert_den_Typ_des_Typarguments()
    {
        var a = new ImplementierungAttribute<StandardRechnung>();
        Assert.Equal(typeof(StandardRechnung), a.Typ);
    }

    // ---------- die angewendeten Attribute

    [Fact]
    public void Rechner_hat_zwei_Autoren()
    {
        var autoren = Attribute.GetCustomAttributes(typeof(Rechner), typeof(AutorAttribute))
            .Cast<AutorAttribute>()
            .OrderBy(a => a.Name, StringComparer.Ordinal)
            .ToList();

        Assert.Equal(2, autoren.Count);
        Assert.Equal("Anna", autoren[0].Name);
        Assert.Equal(2, autoren[0].Version);
        Assert.Equal("Ben", autoren[1].Name);
        Assert.Equal(1, autoren[1].Version);
    }

    [Fact]
    public void Addiere_hat_den_Autor_Ben_in_Version_3_und_Teile_keinen()
    {
        MethodInfo addiere = typeof(Rechner).GetMethod("Addiere")!;
        var autor = Hole<AutorAttribute>(addiere);

        Assert.NotNull(autor);
        Assert.Equal("Ben", autor!.Name);
        Assert.Equal(3, autor.Version);

        MethodInfo teile = typeof(Rechner).GetMethod("Teile")!;
        Assert.Null(Hole<AutorAttribute>(teile));
    }

    [Fact]
    public void Person_markiert_Name_und_Alter_als_Spalten_aber_nicht_das_Passwort()
    {
        string? Spaltenname(string eigenschaft) =>
            Hole<SpalteAttribute>(typeof(Person).GetProperty(eigenschaft)!)?.Name;

        Assert.Equal("name", Spaltenname(nameof(Person.Name)));
        Assert.Equal("alter", Spaltenname(nameof(Person.Alter)));
        Assert.Null(Spaltenname(nameof(Person.Passwort)));
    }

    [Fact]
    public void Rechner_ist_mit_Implementierung_StandardRechnung_markiert()
    {
        var a = Hole<ImplementierungAttribute<StandardRechnung>>(typeof(Rechner));

        Assert.NotNull(a);
        Assert.Equal(typeof(StandardRechnung), a!.Typ);
    }
}
