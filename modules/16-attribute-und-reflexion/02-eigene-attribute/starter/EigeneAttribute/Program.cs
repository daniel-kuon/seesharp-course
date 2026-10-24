foreach (Attribute a in Attribute.GetCustomAttributes(typeof(Rechner)))
    Console.WriteLine(a.GetType().Name);
