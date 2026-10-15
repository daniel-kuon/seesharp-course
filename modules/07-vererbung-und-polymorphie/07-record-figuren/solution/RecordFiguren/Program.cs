var k = new Kreis(50.0, 50.0, 30.0);
var (dx, dy, dr) = k;
Console.WriteLine($"dx={dx}, dy={dy}, dr={dr}"); // erwartet: dx=50, dy=50, dr=30
var k2 = new Kreis(50.0, 50.0, 30.0);
Console.WriteLine(k == k2);                       // True
