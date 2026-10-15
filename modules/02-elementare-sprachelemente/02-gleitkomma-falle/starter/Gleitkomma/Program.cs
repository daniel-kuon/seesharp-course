Console.WriteLine($"0.1 + 0.2 als double:  {Gleitkomma.SummeDouble():R}");
Console.WriteLine($"0.1 + 0.2 als decimal: {Gleitkomma.SummeDecimal()}");
Console.WriteLine($"1 + 2^-52 = {Gleitkomma.EinsPlusZweiHochMinus(52):R}");
Console.WriteLine($"1 + 2^-53 = {Gleitkomma.EinsPlusZweiHochMinus(53):R}");
Console.WriteLine($"2.345 kaufmännisch gerundet: {Gleitkomma.RundeKaufmaennisch(2.345m)}");
