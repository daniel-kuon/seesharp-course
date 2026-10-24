var meldungen = Fehler.Sammle(
    () => 1,
    () => throw new InvalidOperationException("kaputt"),
    () => throw new ArgumentException("ungültig"));
Console.WriteLine(string.Join(" | ", meldungen));

using var cts = new CancellationTokenSource();
using var erreicht = new ManualResetEventSlim();
Task zaehlen = Task.Run(() => Zaehler.ZaehleHoch(cts.Token, erreicht), cts.Token);
erreicht.Wait();
cts.Cancel();
try { zaehlen.Wait(); }
catch (AggregateException) { }
Console.WriteLine($"Abgebrochen: {zaehlen.IsCanceled}");
