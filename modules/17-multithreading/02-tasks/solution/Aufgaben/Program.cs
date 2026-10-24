Console.WriteLine(Berechnungen.SummeParallel(Enumerable.Range(1, 1000).ToArray()));

var sensor = new Sensor();
Task<double> messung = Berechnungen.WartenAufMesswert(sensor);
sensor.Melde(21.5);
Console.WriteLine(messung.Result);
