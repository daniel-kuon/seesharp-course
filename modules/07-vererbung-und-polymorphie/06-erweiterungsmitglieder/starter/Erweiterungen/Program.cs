double pi = 3.14;
Console.WriteLine(pi.High(2));              // 9,8596
Console.WriteLine(pi.EqualsPi);             // False
Console.WriteLine(Math.PI.EqualsPi);        // True
Console.WriteLine(double.DiffThreshold);    // 1E-14
Console.WriteLine(double.NumEqualsPi(pi));  // False
Console.WriteLine(2.0 ^ 3.0);               // 8

string? s = null;
Console.WriteLine(s.Empty());               // False
Console.WriteLine("".Empty());              // True
Console.WriteLine(s.NullOrEmpty);           // True
