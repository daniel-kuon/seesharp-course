using Kontaktverwaltung;
using Microsoft.Data.Sqlite;

public class KontaktdienstTests : IDisposable
{
    private readonly SqliteConnection _c = new("Data Source=:memory:");
    private readonly Kontaktdienst _dienst;

    public KontaktdienstTests()
    {
        _c.Open();
        using var befehl = _c.CreateCommand();
        befehl.CommandText = """
            CREATE TABLE Kontakt (Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Telefon TEXT);
            INSERT INTO Kontakt (Id, Name, Telefon) VALUES
                (1, 'Berta Bauer', '0711 456'),
                (2, 'Anna Albrecht', NULL),
                (3, 'Carl Bauer', '0711 789'),
                (4, 'Dora Dietz', '0711 000');
            """;
        befehl.ExecuteNonQuery();
        _dienst = new Kontaktdienst(_c);
    }

    public void Dispose() => _c.Dispose();

    [Fact]
    public void Neu_liefert_die_neue_Id_und_speichert_den_Kontakt()
    {
        long id = _dienst.Neu("Emil Ebert", "0711 111");
        Assert.True(id > 4);
        Assert.Equal(new Kontakt(id, "Emil Ebert", "0711 111"), _dienst.Suche("Ebert").Single());
    }

    [Fact]
    public void Neu_ohne_Telefon_speichert_NULL()
    {
        long id = _dienst.Neu("Fritz Fuchs", null);
        Assert.Null(_dienst.Suche("Fuchs").Single(k => k.Id == id).Telefon);
    }

    [Fact]
    public void Neu_vertraegt_Hochkommas_und_SQL_Zeichen_im_Namen()
    {
        const string name = "O'Brien'); DROP TABLE Kontakt;--";
        _dienst.Neu(name, "1");
        Assert.Equal(name, _dienst.Suche("Brien").Single().Name);
        Assert.Equal(5, _dienst.Suche("").Count);
    }

    [Fact]
    public void Aendern_aendert_Name_und_Telefon_und_meldet_ob_es_den_Kontakt_gab()
    {
        Assert.True(_dienst.Aendern(2, "Anna Albrecht-Weiß", "0711 222"));
        Assert.Equal(new Kontakt(2, "Anna Albrecht-Weiß", "0711 222"), _dienst.Suche("Albrecht").Single());
        Assert.False(_dienst.Aendern(99, "Niemand", null));
    }

    [Fact]
    public void Aendern_kann_das_Telefon_auf_NULL_setzen()
    {
        Assert.True(_dienst.Aendern(1, "Berta Bauer", null));
        Assert.Null(_dienst.Suche("Berta").Single().Telefon);
    }

    [Fact]
    public void Loeschen_entfernt_nur_den_einen_Kontakt()
    {
        Assert.True(_dienst.Loeschen(3));
        Assert.False(_dienst.Loeschen(3));
        Assert.Equal(new[] { 2L, 1L, 4L }, _dienst.Suche("").Select(k => k.Id));
    }

    [Fact]
    public void Suche_findet_Teiltext_und_sortiert_nach_Name()
    {
        var treffer = _dienst.Suche("Bauer");
        Assert.Equal(new[] { "Berta Bauer", "Carl Bauer" }, treffer.Select(k => k.Name));
    }

    [Fact]
    public void Suche_liefert_auch_Kontakte_ohne_Telefon()
    {
        var anna = Assert.Single(_dienst.Suche("Anna"));
        Assert.Equal(new Kontakt(2, "Anna Albrecht", null), anna);
    }

    [Fact]
    public void Suche_ohne_Treffer_und_mit_SQL_Zeichen_liefert_leere_Liste()
    {
        Assert.Empty(_dienst.Suche("Zzz"));
        Assert.Empty(_dienst.Suche("x' OR '1'='1"));
    }

    [Fact]
    public void Suche_mit_leerem_Text_liefert_alle_sortiert()
    {
        Assert.Equal(new[] { "Anna Albrecht", "Berta Bauer", "Carl Bauer", "Dora Dietz" },
            _dienst.Suche("").Select(k => k.Name));
    }
}
