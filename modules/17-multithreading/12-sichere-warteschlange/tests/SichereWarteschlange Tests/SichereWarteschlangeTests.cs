using System.Collections.Concurrent;

public class SichereWarteschlangeTests
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(60);   // nur Schutz vor einem Hänger

    [Fact]
    public void Elemente_kommen_in_der_Reihenfolge_des_Einreihens_heraus()
    {
        var q = new SichereWarteschlange<string>();
        Assert.Equal(0, q.Anzahl);

        q.Einreihen("a");
        q.Einreihen("b");
        q.Einreihen("c");
        Assert.Equal(3, q.Anzahl);

        Assert.True(q.TryNaechster(out string? erstes));
        Assert.True(q.TryNaechster(out string? zweites));
        Assert.True(q.TryNaechster(out string? drittes));
        Assert.Equal(new[] { "a", "b", "c" }, new[] { erstes, zweites, drittes });
        Assert.Equal(0, q.Anzahl);
    }

    [Fact]
    public void Eine_leere_Warteschlange_liefert_false_und_den_Standardwert()
    {
        var q = new SichereWarteschlange<int>();

        Assert.False(q.TryNaechster(out int wert));
        Assert.Equal(0, wert);

        q.Einreihen(5);
        Assert.True(q.TryNaechster(out wert));
        Assert.Equal(5, wert);
        Assert.False(q.TryNaechster(out _));
    }

    [Fact]
    public void Vier_Erzeuger_und_vier_Verbraucher_jedes_Element_genau_einmal()
    {
        const int Erzeuger = 4, Verbraucher = 4, ProErzeuger = 2_500;
        var q = new SichereWarteschlange<int>();
        var verbraucht = new ConcurrentBag<int>();
        var fehler = new ConcurrentBag<Exception>();
        using var alleEingereiht = new ManualResetEventSlim();
        var start = new Barrier(Erzeuger + Verbraucher);

        Thread Starte(Action arbeit)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    start.SignalAndWait();   // alle fangen im selben Moment an
                    arbeit();
                }
                catch (Exception ex)
                {
                    fehler.Add(ex);
                }
            });
            thread.Start();
            return thread;
        }

        var erzeuger = Enumerable.Range(0, Erzeuger).Select(nr => Starte(() =>
        {
            for (int i = 0; i < ProErzeuger; i++)
                q.Einreihen(nr * ProErzeuger + i);   // jedes Element ist einmalig
        })).ToList();

        var verbraucherThreads = Enumerable.Range(0, Verbraucher).Select(_ => Starte(() =>
        {
            while (true)
            {
                if (q.TryNaechster(out int wert))
                {
                    verbraucht.Add(wert);
                    continue;
                }
                // Leer: Ist alles eingereiht und nichts mehr da, ist die Arbeit getan. Sonst kurz abgeben und weiter.
                if (alleEingereiht.IsSet && q.Anzahl == 0)
                    break;
                Thread.Yield();
            }
        })).ToList();

        foreach (Thread t in erzeuger)
            Assert.True(t.Join(Wartegrenze), "Ein Erzeuger wurde nicht fertig.");
        alleEingereiht.Set();   // ab jetzt kommt nichts mehr dazu
        foreach (Thread t in verbraucherThreads)
            Assert.True(t.Join(Wartegrenze), "Ein Verbraucher wurde nicht fertig.");

        Assert.Empty(fehler);
        Assert.Equal(Erzeuger * ProErzeuger, verbraucht.Count);
        Assert.Equal(Enumerable.Range(0, Erzeuger * ProErzeuger), verbraucht.OrderBy(x => x));   // keines doppelt, keines verloren
        Assert.Equal(0, q.Anzahl);
    }
}
