public class ThermostatTests
{
    private class ZaehlendesThermostat : Thermostat
    {
        public int Ausloesungen;

        protected override void OnTemperaturGeaendert(TemperaturGeaendertEventArgs e)
        {
            Ausloesungen++;
            base.OnTemperaturGeaendert(e);
        }
    }

    [Fact]
    public void Aenderung_loest_TemperaturGeaendert_aus()
    {
        var t = new Thermostat { Temperatur = 20 };
        object? absender = null;
        TemperaturGeaendertEventArgs? args = null;
        t.TemperaturGeaendert += (s, e) => { absender = s; args = e; };

        t.Temperatur = 25.5;

        Assert.Same(t, absender);
        Assert.NotNull(args);
        Assert.Equal(20, args.Alt);
        Assert.Equal(25.5, args.Neu);
        Assert.Equal(25.5, t.Temperatur);
    }

    [Fact]
    public void Gleicher_Wert_loest_nichts_aus()
    {
        var t = new Thermostat { Temperatur = 20 };
        int aufrufe = 0;
        t.TemperaturGeaendert += (s, e) => aufrufe++;

        t.Temperatur = 20;

        Assert.Equal(0, aufrufe);
    }

    [Fact]
    public void Ohne_Abonnenten_passiert_nichts()
    {
        var t = new Thermostat { Grenze = 30 };

        t.Temperatur = 99;   // beide Ereignisse ohne Abonnenten: darf nicht werfen

        Assert.Equal(99, t.Temperatur);
    }

    [Fact]
    public void Mehrere_Abonnenten_werden_benachrichtigt()
    {
        var t = new Thermostat();
        var log = new List<string>();
        t.TemperaturGeaendert += (s, e) => log.Add("A" + e.Neu);
        t.TemperaturGeaendert += (s, e) => log.Add("B" + e.Neu);

        t.Temperatur = 21;

        Assert.Equal(["A21", "B21"], log);
    }

    [Fact]
    public void Ueberhitzt_nur_ueber_der_Grenze()
    {
        var t = new Thermostat { Grenze = 30 };
        object? absender = null;
        int ueberhitzt = 0;
        t.Ueberhitzt += (s, e) => { absender = s; ueberhitzt++; };

        t.Temperatur = 30;   // genau die Grenze: noch nicht überhitzt
        Assert.Equal(0, ueberhitzt);

        t.Temperatur = 30.1;
        Assert.Equal(1, ueberhitzt);
        Assert.Same(t, absender);

        t.Temperatur = 30.1;   // keine Änderung, kein Ereignis
        Assert.Equal(1, ueberhitzt);

        t.Temperatur = 31;
        Assert.Equal(2, ueberhitzt);

        t.Temperatur = 10;   // abgekühlt: kein Ereignis
        Assert.Equal(2, ueberhitzt);
    }

    [Fact]
    public void Ueberhitzt_kommt_nach_TemperaturGeaendert()
    {
        var t = new Thermostat { Grenze = 30 };
        var log = new List<string>();
        t.Ueberhitzt += (s, e) => log.Add("ueberhitzt");
        t.TemperaturGeaendert += (s, e) => log.Add("geaendert");

        t.Temperatur = 40;

        Assert.Equal(["geaendert", "ueberhitzt"], log);
    }

    [Fact]
    public void Erben_koennen_die_Ausloesung_kontrollieren()
    {
        var t = new ZaehlendesThermostat();
        int ereignisse = 0;
        t.TemperaturGeaendert += (s, e) => ereignisse++;

        t.Temperatur = 21;
        t.Temperatur = 21;
        t.Temperatur = 22;

        Assert.Equal(2, t.Ausloesungen);
        Assert.Equal(2, ereignisse);   // base wurde aufgerufen
    }

    [Fact]
    public void Ereignisse_sind_echte_Ereignisse()
    {
        // Ein öffentliches Delegatenfeld wäre kein Ereignis: Von außen ließe es sich aufrufen und überschreiben.
        Assert.NotNull(typeof(Thermostat).GetEvent(nameof(Thermostat.TemperaturGeaendert)));
        Assert.NotNull(typeof(Thermostat).GetEvent(nameof(Thermostat.Ueberhitzt)));
        Assert.Null(typeof(Thermostat).GetField(nameof(Thermostat.TemperaturGeaendert)));
        Assert.Null(typeof(Thermostat).GetField(nameof(Thermostat.Ueberhitzt)));
    }

    [Fact]
    public void EventArgs_sind_von_EventArgs_abgeleitet()
    {
        Assert.True(typeof(EventArgs).IsAssignableFrom(typeof(TemperaturGeaendertEventArgs)));
        var e = new TemperaturGeaendertEventArgs(1, 2);
        Assert.Equal(1, e.Alt);
        Assert.Equal(2, e.Neu);
    }
}
